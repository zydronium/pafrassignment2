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
    public partial class FrmNewPurpose : ObserverForm
    {
        private bool exitform = false;
        public bool editScreen = false;
        public Purpose editPurpose;

        public FrmNewPurpose(ObservableForm reference)
        {
            InitializeComponent();
            this.receiver = reference;
            this.FormClosing += this.FrmNewPurpose_FormClosing;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void FrmNewPurpose_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                string message = "";
                if (editScreen)
                {
                    message = "Cancel editing purpose?";
                }
                else
                {
                    message = "Cancel creating new purpose?";
                }
                if (MessageBox.Show(message, "PatternBase",
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

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnAdd_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (editScreen)
            {
                editPurpose.setName(txtName.Text);
                editPurpose.setDescription(txtDescription.Text);
            }
            else
            {
                btnDelete.Visible = false;
                Purpose purpose = new Purpose();
                purpose.setName(txtName.Text);
                purpose.setDescription(txtDescription.Text);
                purpose.setId(Program.database.getId());

                KeyValue parentItem = (KeyValue)cbbParrent.SelectedItem;
                Purpose parent = Program.database.getPurposeById(Convert.ToInt32(parentItem.key));
                purpose.setParentId(parent.getId());
                parent.AddSubComponent(purpose);
            }

            this.receiver.Updater();
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
            this.ActiveControl = this.txtName;

            if (editScreen)
            {
                btnAdd.Text = "Edit";
                this.Text = "Edit Purpose";
                txtName.Text = editPurpose.getName();
                txtDescription.Text = editPurpose.getDescription();
                lblParent.Visible = false;
                cbbParrent.Visible = false;
                if (editPurpose.getId() == 2)
                {
                    btnDelete.Visible = false;
                }
            }
        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            cbbParrent.Items.Add(keyValue);
            foreach (ComponentModel pur in purp.getSubComponents())
            {
                if (pur.GetType() == typeof(Purpose))
                {
                    this.fetchSubCategories((Purpose)pur, "- " + prefix);
                }
            }
        }
        new public void Updater() { }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Purpose parent = Program.database.getPurposeById(editPurpose.getParentId());
            parent.RemoveSubComponent(editPurpose);

            this.receiver.Updater();
            exitform = true;
            this.Close();
        }
        

    }
}
