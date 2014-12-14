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
    public partial class FrmNewScope : Form
    {
        private bool exitform = false;

        public FrmNewScope()
        {
            InitializeComponent();
            this.FormClosing += this.FrmNewScope_FormClosing;
        }

        private void FrmNewScope_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                if (MessageBox.Show("Cancel creating new scope?", "PatternBase",
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
            Scope scope = new Scope();
            scope.setName(txtName.Text);
            scope.setDescription(txtDescription.Text);
            scope.setId(Program.database.getId());

            KeyValue parentItem = (KeyValue)cbbParrent.SelectedItem;
            Scope parent = Program.database.getScopeById(Convert.ToInt32(parentItem.key));
            parent.AddSubCategory(scope);
            Program.database.addScope(scope);
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
        }

        private void fetchSubCategories(Scope sco, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = sco.getId().ToString();
            keyValue.value = prefix + sco.getName();
            cbbParrent.Items.Add(keyValue);
            foreach (Scope sc in sco.getSubCategories())
            {
                this.fetchSubCategories(sc, "- " + prefix);
            }
        }
    }
}
