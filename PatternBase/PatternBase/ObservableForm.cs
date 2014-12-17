using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    public abstract class ObservableForm : Form
    {
        private List<ObserverForm> observers = new List<ObserverForm>();

        public void Attach(ObserverForm observer)
        {
            observers.Add(observer);
        }

        public void Detach(ObserverForm observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (ObserverForm observer in observers)
            {
                observer.Updater();
            }
        }

        public void ForceCloseObservers()
        {
            List<ObserverForm> list = new List<ObserverForm>();
            foreach (ObserverForm observer in observers)
            {
                list.Add(observer);
            }
            foreach (ObserverForm observer in list)
            {
                this.Detach(observer);
                observer.ForceClose();
            }
        }

        public abstract void Updater();
    }
}
