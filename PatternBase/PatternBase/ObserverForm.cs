using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    public abstract class ObserverForm : Form
    {
         protected ObservableForm receiver;
         public abstract void Updater();
    }
}
