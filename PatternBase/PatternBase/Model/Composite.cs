using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public class Composite : Component
    {
        public List<Component> subcategories = new List<Component>();

        public void AddSubComponent(Component cat)
        {
            subcategories.Add(cat);
        }

        public void RemoveSubComponent(Component cat)
        {
            subcategories.Remove(cat);
        }

        public Component GetSubComponent(int index)
        {
            return subcategories[index];
        }

        public List<Component> getSubComponents()
        {
            return subcategories;
        }

    }
}

