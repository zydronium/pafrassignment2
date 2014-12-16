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
    public partial class FrmNewPattern : Form
    {
        private bool exitform = false;
        private FolderBrowserDialog folderBrowserDialog;
        private OpenFileDialog openFileDialog;
        public bool editScreen = false;
        public Pattern editPattern;

        public FrmNewPattern()
        {
            InitializeComponent();
            this.FormClosing += this.FrmNewPattern_FormClosing;
        }

        private void FrmNewPattern_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                string message = "";
                if (editScreen)
                {
                    message = "Cancel editing patterm?";
                }
                else
                {
                    message = "Cancel creating new pattern?";
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
            Pattern patternId = new Pattern();
            Pattern pattern = new Pattern();
            if (editScreen)
            {
                editPattern.setName(txtName.Text);
                editPattern.setDescription(txtDescription.Text);
                editPattern.setId(Program.database.getId());
                editPattern.setProblem(txtProblem.Text);
                editPattern.setConsequence(txtConsequence.Text);
                editPattern.setSolution(txtSolution.Text);
                patternId.setId(editPattern.getId());
            }
            else
            {
                pattern.setName(txtName.Text);
                pattern.setDescription(txtDescription.Text);
                pattern.setId(Program.database.getId());
                pattern.setProblem(txtProblem.Text);
                pattern.setConsequence(txtConsequence.Text);
                pattern.setSolution(txtSolution.Text);
                patternId.setId(pattern.getId());
                Program.database.addPattern(pattern);
            }

            KeyValue parentItemPurpose = (KeyValue)lbParrentPurpose.SelectedItem;
            Purpose parentPurpose = Program.database.getPurposeById(Convert.ToInt32(parentItemPurpose.key));
            KeyValue parentItemScope = (KeyValue)lbParrentScope.SelectedItem;
            Scope parentScope = Program.database.getScopeById(Convert.ToInt32(parentItemScope.key));
            if (editScreen)
            {
                foreach (Scope scope in editPattern.getScopeList())
                {
                    ComponentModel patternForRemove;
                    patternForRemove = scope.GetSubComponentById(editPattern.getId());
                    scope.RemoveSubComponent(patternForRemove);
                }
                foreach (Purpose purpose in editPattern.getPurposeList())
                {
                    ComponentModel patternForRemove;
                    patternForRemove = purpose.GetSubComponentById(editPattern.getId());
                    purpose.RemoveSubComponent(patternForRemove);
                }

                parentScope.AddSubComponent(patternId);
                parentPurpose.AddSubComponent(patternId);

                editPattern.addPurpose(parentPurpose);
                editPattern.addScope(parentScope);
            }
            else
            {
                parentScope.AddSubComponent(patternId);
                parentPurpose.AddSubComponent(patternId);

                pattern.addPurpose(parentPurpose);
                pattern.addScope(parentScope);
            }

            exitform = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewPattern_Load(object sender, EventArgs e)
        {
            Scope scope = Program.database.getHeadScope();
            fetchSubCategories(scope, "");
            lbParrentScope.DisplayMember = "value";
            lbParrentScope.ValueMember = "key";

            Purpose purpose = Program.database.getHeadPurpose();
            fetchSubCategories(purpose, "");
            lbParrentPurpose.DisplayMember = "value";
            lbParrentPurpose.ValueMember = "key";

            if (editScreen)
            {
                btnAdd.Text = "Edit";
                this.Text = "Edit Pattern";
                txtName.Text = editPattern.getName();
                txtDescription.Text = editPattern.getDescription();
            }
        }

        private void fetchSubCategories(Scope sco, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = sco.getId().ToString();
            keyValue.value = prefix + sco.getName();
            lbParrentScope.Items.Add(keyValue);
            foreach (ComponentModel sc in sco.getSubComponents())
            {
                if (sc.GetType() == typeof(Scope)) {
                    this.fetchSubCategories((Scope)sc, "- " + prefix);
                }
            }
        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            lbParrentPurpose.Items.Add(keyValue);
            foreach (ComponentModel pur in purp.getSubComponents())
            {
                if (pur.GetType() == typeof(Purpose)) {
                    this.fetchSubCategories((Purpose)pur, "- " + prefix);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }
    }
}
