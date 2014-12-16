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
    public partial class FrmNewScope : ObserverForm
    {
        private bool exitform = false;
        public bool editScreen = false;
        public Scope editScope;

        public FrmNewScope(ObservableForm reference)
        {
            InitializeComponent();
            this.receiver = reference;
            this.FormClosing += this.FrmNewScope_FormClosing;
        }

        private void FrmNewScope_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                string message = "";
                if (editScreen)
                {
                    message = "Cancel editing scope?";
                }
                else
                {
                    message = "Cancel creating new scope?";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (editScreen)
            {
                editScope.setName(txtName.Text);
                editScope.setDescription(txtDescription.Text);
            }
            else
            {
                btnDelete.Visible = false;
                Scope scope = new Scope();
                scope.setName(txtName.Text);
                scope.setDescription(txtDescription.Text);
                scope.setId(Program.database.getId());

                KeyValue parentItem = (KeyValue)cbbParrent.SelectedItem;
                Scope parent = Program.database.getScopeById(Convert.ToInt32(parentItem.key));
                parent.AddSubComponent(scope);
            }

            this.receiver.Updater();
            exitform = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewScope_Load(object sender, EventArgs e)
        {
            Scope scope = Program.database.getHeadScope();
            fetchSubCategories(scope, "");
            cbbParrent.DisplayMember = "value";
            cbbParrent.ValueMember = "key";
            cbbParrent.SelectedIndex = 0;

            if (editScreen)
            {
                btnAdd.Text = "Edit";
                this.Text = "Edit Scope";
                txtName.Text = editScope.getName();
                txtDescription.Text = editScope.getDescription();
                lblParent.Visible = false;
                cbbParrent.Visible = false;
            }
        }

        private void fetchSubCategories(Scope sco, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = sco.getId().ToString();
            keyValue.value = prefix + sco.getName();
            cbbParrent.Items.Add(keyValue);
            foreach (ComponentModel sc in sco.getSubComponents())
            {
                if (sc.GetType() == typeof(Scope))
                {
                    this.fetchSubCategories((Scope)sc, "- " + prefix);
                }
            }
        }
        new public void Updater() { }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
