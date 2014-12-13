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

        public FrmEditor()
        {
            InitializeComponent();
            this.FormClosing += this.FrmEditor_FormClosing;
        }

        private void FrmEditor_FormClosing(Object sender, FormClosingEventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort. 
            if (MessageBox.Show("Do you want to discart your changes?", "My Application",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
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
}
