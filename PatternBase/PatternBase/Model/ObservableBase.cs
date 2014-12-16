using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public abstract class ObservableBase
    {
        private ArrayList observers = new ArrayList();

        public void Attach(ObserverBase monitor)
        {
            observers.Add(monitor);
        }

        public void Remove(ObserverBase monitor)
        {
            observers.Remove(monitor);
        }

        public void Notify()
        {
            foreach (ObserverBase monitor in observers)
            {
                monitor.Update();
            }
        }
    }
}
