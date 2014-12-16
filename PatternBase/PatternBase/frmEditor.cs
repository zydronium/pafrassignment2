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
    public partial class FrmEditor : ObservableForm
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
            Program.frmNewPurpose = new FrmNewPurpose(this);
            this.Attach(Program.frmNewPurpose);
            Program.frmNewPurpose.Show();
        }

        private void btnNewScope_Click(object sender, EventArgs e)
        {
            Program.frmNewScope = new FrmNewScope(this);
            this.Attach(Program.frmNewPurpose);
            Program.frmNewScope.Show();
        }

        private void btnNewPattern_Click(object sender, EventArgs e)
        {
            Program.frmNewPattern = new FrmNewPattern(this);
            this.Attach(Program.frmNewPurpose);
            Program.frmNewPattern.Show();
        }

        public void loadElements()
        {
            this.lbPurpose.Items.Clear();
            this.lbScope.Items.Clear();
            this.lbEditScope.Items.Clear();
            this.lbEditPattern.Items.Clear();
            this.lbEditPurpose.Items.Clear();
            Scope scope = Program.database.getHeadScope();
            fetchSubCategories(scope, "", lbScope);
            lbScope.DisplayMember = "value";
            lbScope.ValueMember = "key";

            Purpose purpose = Program.database.getHeadPurpose();
            fetchSubCategories(purpose, "", lbPurpose);
            lbPurpose.DisplayMember = "value";
            lbPurpose.ValueMember = "key";

            Scope editScope = Program.database.getHeadScope();
            fetchSubCategories(scope, "", lbEditScope);
            lbEditScope.DisplayMember = "value";
            lbEditScope.ValueMember = "key";

            Purpose editPurpose = Program.database.getHeadPurpose();
            fetchSubCategories(purpose, "", lbEditPurpose);
            lbEditPurpose.DisplayMember = "value";
            lbEditPurpose.ValueMember = "key";

            foreach (Pattern pur in Program.database.getPatternList())
            {
                KeyValue keyValue = new KeyValue();
                keyValue.key = pur.getId().ToString();
                keyValue.value = pur.getName();
                lbEditPattern.Items.Add(keyValue);
            }
            lbEditPattern.DisplayMember = "value";
            lbEditPattern.ValueMember = "key";
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.loadElements();
        }

        private void fetchSubCategories(Purpose purp, string prefix, ListBox lbox)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            lbox.Items.Add(keyValue);
            foreach (ComponentModel pur in purp.getSubComponents())
            {
                if (pur.GetType() == typeof(Purpose))
                {
                    this.fetchSubCategories((Purpose)pur, "- " + prefix, lbox);
                }
            }
        }

        private void fetchSubCategories(Scope scope, string prefix, ListBox lbox)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = scope.getId().ToString();
            keyValue.value = prefix + scope.getName();
            lbox.Items.Add(keyValue);
            foreach (ComponentModel sco in scope.getSubComponents())
            {
                if (sco.GetType() == typeof(Scope))
                {
                    this.fetchSubCategories((Scope)sco, "- " + prefix, lbox);
                }
            }
        }


        public override void Updater() 
        {
            this.loadElements();
        }
        private void lbEditPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValue item = (KeyValue)lbEditPurpose.SelectedItem;
            Purpose purpose = Program.database.getPurposeById(Convert.ToInt32(item.key));
            Program.frmNewPurpose = new FrmNewPurpose(this);
            Program.frmNewPurpose.editScreen = true;
            Program.frmNewPurpose.editPurpose = purpose;
            Program.frmNewPurpose.Show();
        }

        private void lbEditScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValue item = (KeyValue)lbEditScope.SelectedItem;
            Scope scope = Program.database.getScopeById(Convert.ToInt32(item.key));
            Program.frmNewScope = new FrmNewScope(this);
            Program.frmNewScope.editScreen = true;
            Program.frmNewScope.editScope = scope;
            Program.frmNewScope.Show();
        }

        private void lbEditPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValue item = (KeyValue)lbEditPattern.SelectedItem;
            Pattern pattern = Program.database.getPatternById(Convert.ToInt32(item.key));
            Program.frmNewPattern = new FrmNewPattern(this);
            Program.frmNewPattern.editScreen = true;
            Program.frmNewPattern.editPattern = pattern;
            Program.frmNewPattern.Show();

        }
    }
}
