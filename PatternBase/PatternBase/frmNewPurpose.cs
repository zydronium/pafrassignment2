using PatternBase.Model;
using PatternBase.Objects;
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
            Purpose purpose = new Purpose();
            purpose.setName(txtName.Text);
            purpose.setDescription(txtDescription.Text);
            purpose.setId(Program.database.getId());

            KeyValue parentItem = (KeyValue)cbbParrent.SelectedItem;
            Purpose parent = Program.database.getPurposeById(Convert.ToInt32(parentItem.key));
            parent.AddSubCategory(purpose);
            Program.database.addPurpose(purpose);
            exitform = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewPurpose_Load(object sender, EventArgs e)
        {
            Purpose purpose = Program.database.getHeadPurpose();
            fetchSubCategories(purpose, "");
            cbbParrent.DisplayMember = "value";
            cbbParrent.ValueMember = "key";
            cbbParrent.SelectedIndex = 0;
        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            cbbParrent.Items.Add(keyValue);
            foreach (Purpose pur in purp.getSubCategories())
            {
                this.fetchSubCategories(pur, "- " + prefix);
            }
        }
    }
}
