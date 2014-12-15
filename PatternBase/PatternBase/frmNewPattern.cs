﻿using PatternBase.Model;
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
                if (MessageBox.Show("Cancel creating new pattern?", "PatternBase",
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
            Pattern pattern = new Pattern();
            pattern.setName(txtName.Text);
            pattern.setDescription(txtDescription.Text);
            pattern.setId(Program.database.getId());
            ComponentId componentId = new ComponentId();
            componentId.setId(pattern.getId());

            KeyValue parentItemPurpose = (KeyValue)lbParrentPurpose.SelectedItem;
            Purpose parentPurpose = Program.database.getPurposeById(Convert.ToInt32(parentItemPurpose.key));
            pattern.addPurpose(parentPurpose);
            parentPurpose.AddSubComponent(componentId);
            KeyValue parentItemScope = (KeyValue)lbParrentScope.SelectedItem;
            Scope parentScope = Program.database.getScopeById(Convert.ToInt32(parentItemScope.key));
            pattern.addScope(parentScope);
            parentScope.AddSubComponent(componentId);

            Program.database.addPattern(pattern);
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
        }

        private void fetchSubCategories(Scope sco, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = sco.getId().ToString();
            keyValue.value = prefix + sco.getName();
            lbParrentScope.Items.Add(keyValue);
            foreach (Scope sc in sco.getSubComponent())
            {
                this.fetchSubCategories(sc, "- " + prefix);
            }
        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            lbParrentPurpose.Items.Add(keyValue);
            foreach (Purpose pur in purp.getSubComponent())
            {
                this.fetchSubCategories(pur, "- " + prefix);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }
    }
}
