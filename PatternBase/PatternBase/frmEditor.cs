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
        //    this.FormClosing += this.FrmEditor_FormClosing;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
            {
                if (MessageBox.Show("Really?", "Close", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        private void FrmEditor_FormClosing(Object sender, FormClosingEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
