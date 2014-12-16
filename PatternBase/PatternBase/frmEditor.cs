using PatternBase.Export;
using PatternBase.Model;
using PatternBase.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    public partial class FrmEditor : Form
    {
        private bool exitform = false;
        private FolderBrowserDialog folderBrowserDialog;
        private SaveFileDialog saveFileDialog;

        public FrmEditor()
        {
            InitializeComponent();
            this.FormClosing += this.FrmEditor_FormClosing;
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog.DefaultExt = "ptdb";
            this.saveFileDialog.Filter = "ptdb files (*.ptdb)|*.ptdb";
        }

        private void FrmEditor_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                if (MessageBox.Show("Do you want to discart your changes?", "PatternBase",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    exitform = true;
                    Application.Exit();
                }
                else
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            // If a file is not opened, then set the initial directory to the 
            // FolderBrowserDialog.SelectedPath value. 
            saveFileDialog.InitialDirectory = folderBrowserDialog.SelectedPath;
            saveFileDialog.FileName = null;

            // Display the openFile dialog.
            DialogResult result = saveFileDialog.ShowDialog();

            // OK button was pressed. 
            if (result == DialogResult.OK)
            {
                string openFileName = saveFileDialog.FileName;
                try
                {
                    // Output the requested file in richTextBox1.
                    ExportContext export = new ExportContext(new XmlStrategy());
                    export.SaveDatabase(openFileName, Program.database);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to save the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    return;
                }
            }

            // Cancel button was pressed. 
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void bbtnNewPurpose_Click(object sender, EventArgs e)
        {
            Program.frmNewPurpose = new FrmNewPurpose();
            Program.frmNewPurpose.Show();
        }

        private void btnNewScope_Click(object sender, EventArgs e)
        {
            Program.frmNewScope = new FrmNewScope();
            Program.frmNewScope.Show();
        }

        private void btnNewPattern_Click(object sender, EventArgs e)
        {
            Program.frmNewPattern = new FrmNewPattern();
            Program.frmNewPattern.Show();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;

            Scope scope = Program.database.getHeadScope();
            fetchSubCategories(scope, "");
            lbScope.DisplayMember = "value";
            lbScope.ValueMember = "key";

            Purpose purpose = Program.database.getHeadPurpose();
            fetchSubCategories(purpose, "");
            lbPurpose.DisplayMember = "value";
            lbPurpose.ValueMember = "key";

        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            lbPurpose.Items.Add(keyValue);
            foreach (ComponentModel pur in purp.getSubComponents())
            {
                if (pur.GetType() == typeof(Purpose))
                {
                    this.fetchSubCategories((Purpose)pur, "- " + prefix);
                }
            }
        }

        private void fetchSubCategories(Scope scope, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = scope.getId().ToString();
            keyValue.value = prefix + scope.getName();
            lbScope.Items.Add(keyValue);
            foreach (ComponentModel sco in scope.getSubComponents())
            {
                if (sco.GetType() == typeof(Scope))
                {
                    this.fetchSubCategories((Scope)sco, "- " + prefix);
                }
            }
        }
    }
}
