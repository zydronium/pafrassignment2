using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    class CompositeCategory : Category
    {
        private List<Category> subcategories = new List<Category>();

        public void AddSubCategory(Category cat)
        {
            subcategories.Add(cat);
        }

        public void RemoveSubCategory(Category cat)
        {
            subcategories.Remove(cat);
        }

        public Category GetSubCategory(int index)
        {
            return subcategories[index];
        }

    }
}

