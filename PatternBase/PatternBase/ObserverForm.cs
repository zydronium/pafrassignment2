using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    public class ObserverForm : Form
    {
        protected bool exitform = false;
        protected ObservableForm receiver;
        public void Updater() { }

        public void ForceClose()
        {
            this.exitform = true;
            this.Close();
        }
    }
}
