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
                    export.SaveDatabase(openFileName, ModelContext.database);
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

        }

        private void btnNewScope_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPattern_Click(object sender, EventArgs e)
        {

        }
    }
}
