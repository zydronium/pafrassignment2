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
        private List<Component> subcategories = new List<Component>();

        public void AddSubCategory(Component cat)
        {
            subcategories.Add(cat);
        }

        public void RemoveSubCategory(Component cat)
        {
            subcategories.Remove(cat);
        }

        public Component GetSubCategory(int index)
        {
            return subcategories[index];
        }

    }
}

