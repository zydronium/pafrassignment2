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
        public List<ComponentModel> subcomponents = new List<ComponentModel>();
        public int parentId;

        public int getParentId()
        {
            return parentId;
        }

        public void setParentId(int i)
        {
            parentId = i;
        }

        public void AddSubComponent(ComponentModel cat)
        {
            subcomponents.Add(cat);
        }

        public void RemoveSubComponent(ComponentModel cat)
        {
            subcomponents.Remove(cat);
        }

        public ComponentModel GetSubComponent(int index)
        {
            return subcomponents[index];
        }

        public ComponentModel GetSubComponent(string patName)
        {
            foreach (ComponentModel subcomponent in subcomponents)
            {
                if (subcomponent.getName() == patName)
                {
                    return subcomponent;
                }
            }
            return null;
        }

        public ComponentModel GetSubComponentById(int id)
        {
            foreach (ComponentModel subcomponent in subcomponents)
            {
                if (subcomponent.getId() == id)
                {
                    return subcomponent;
                }
            }
            return null;
        }

        public List<ComponentModel> getSubComponents()
        {
            return subcomponents;
        }

    }
}

