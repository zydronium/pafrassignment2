using PatternBase.Model;
using System;
using System.Collections;
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
    public partial class FrmNewPurpose : Form
    {
        private bool exitform = false;
        private ArrayList values = new ArrayList();

        public FrmNewPurpose()
        {
            InitializeComponent();
            this.FormClosing += this.FrmNewPurpose_FormClosing;
        }

        private void FrmNewPurpose_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                if (MessageBox.Show("Cancel creating new purpose?", "PatternBase",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    exitform = true;
                }
                else
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewPurpose_Load(object sender, EventArgs e)
        {
            Purpose purpose = ModelContext.database.getHeadPurpose();
            fetchSubCategories(purpose, "");
            //  values.Add(ModelContext.database.getHeadPurpose());

        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            purp.setName(prefix + purp.getName());
            values.Add(purp);
            foreach (Purpose pur in purp.getSubCategories())
            {
                this.fetchSubCategories(pur, "- "+prefix);
            }
        }
    }
}
