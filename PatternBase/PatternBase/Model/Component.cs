using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    abstract public class Component
    {
        public string name;
        public string description;
        public int id;
        public List<Pattern> patterns = new List<Pattern>();

        public string getName()
        {
            return name;
        }

        public void setName(string nm)
        {
            name = nm;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int i)
        {
            id = i;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string desc)
        {
            description = desc;
        }

        public List<Pattern> getPatternList()
        {
            return patterns;
        }

        public void setPatternList(List<Pattern> pattlist)
        {
            patterns = pattlist;
        }

        public Pattern getPattern(string patName)
        {
            foreach (Pattern pattern in patterns)
            {
                if (pattern.getName() == patName)
                {
                    return pattern;
                }
            }
            return null;
        }

        public Pattern getPatternById(int id)
        {
            foreach (Pattern pattern in patterns)
            {
                if (pattern.getId() == id)
                {
                    return pattern;
                }
            }
            return null;
        }

        public void addPattern(Pattern pattern)
        {
            patterns.Add(pattern);
        }

        public void removePattern(Pattern pattern)
        {
            patterns.Remove(pattern);
        }
    }
}
