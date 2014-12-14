using PatternBase.Export;
using PatternBase.Model;
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
    public partial class FrmStart : Form
    {
        private FolderBrowserDialog folderBrowserDialog;
        private OpenFileDialog openFileDialog;

        public FrmStart()
        {
            InitializeComponent();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog.DefaultExt = "ptdb";
            this.openFileDialog.Filter = "ptdb files (*.ptdb)|*.ptdb";

            this.FormClosing += this.FrmStart_FormClosing;
        }

        private void FrmStart_FormClosing(Object sender, FormClosingEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text. 
            Application.Exit();
        }

        private void btnNewDatabase_Click(object sender, EventArgs e)
        {
            ModelContext.database = new Database();

            Scope scope = new Scope();
            scope.setName("Scope");
            scope.setId(ModelContext.database.getId());
            scope.setDescription("Head of hierachy");
            Purpose purpose = new Purpose();
            purpose.setName("Purpose");
            purpose.setId(ModelContext.database.getId());
            purpose.setDescription("Head of hierachy");

            ModelContext.database.setHeadScope(scope);
            ModelContext.database.setHeadPurpose(purpose);
            ModelContext.database.id = 0;

            ModelContext.database.addPurpose(purpose);
            ModelContext.database.addScope(scope);

            Program.frmEditor.Show();
            Program.frmStart.Hide();
        }

        private void btnSelectDatabase_Click(object sender, EventArgs e)
        {
            // If a file is not opened, then set the initial directory to the 
            // FolderBrowserDialog.SelectedPath value. 
            openFileDialog.InitialDirectory = folderBrowserDialog.SelectedPath;
            openFileDialog.FileName = null;

            // Display the openFile dialog.
            DialogResult result = openFileDialog.ShowDialog();

            // OK button was pressed. 
            if (result == DialogResult.OK)
            {
                string openFileName = openFileDialog.FileName;
                try
                {
                    // Output the requested file in richTextBox1.
                    ExportContext export = new ExportContext(new XmlStrategy());
                    ModelContext.database = export.OpenDatabase(openFileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    return;
                }
            }

            // Cancel button was pressed. 
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            Program.frmEditor.Show();
            Program.frmStart.Hide();
        }
    }
}
