using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    abstract class Category : IEnumerable<Category>
    {
        abstract public string name;
        abstract public string description;
        private List<Category> subcategories = new List<Category>();

        abstract public string getName()
        {
            return name;
        }

        abstract public void setName(string nm)
        {
            name = nm;
        }

        abstract public string getDescription()
        {
            return description;
        }

        abstract public void setDescription(string desc)
        {
            description = desc;
        }

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

        public IEnumerator<Category> getEnumerator()
        {
            foreach (Category subcategory in subcategories)
            {
                yield return subcategory;
            }
        }

        IEnumerator<Category> IEnumerable<Category>.getEnumerator()
        {
            return getEnumerator();
        }
    }
}
