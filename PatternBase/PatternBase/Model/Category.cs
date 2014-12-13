using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    abstract class Category
    {
        abstract public string name;
        abstract public string description;

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
    }
}
