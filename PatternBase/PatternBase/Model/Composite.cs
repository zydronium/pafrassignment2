using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public class Composite : ComponentModel
    {
        public List<ComponentModel> subcategories = new List<ComponentModel>();

        public void AddSubComponent(ComponentModel cat)
        {
            subcategories.Add(cat);
        }

        public void RemoveSubComponent(ComponentModel cat)
        {
            subcategories.Remove(cat);
        }

        public ComponentModel GetSubComponent(int index)
        {
            return subcategories[index];
        }

        public List<ComponentModel> getSubComponents()
        {
            return subcategories;
        }

    }
}

