using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public class Database
    {
        public List<Pattern> patterns = new List<Pattern>();

        public Scope headScope;
        public Purpose headPurpose;

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

        public void addPattern(Pattern pattern)
        {
            patterns.Add(pattern);
        }

        public void removePattern(Pattern pattern)
        {
            patterns.Remove(pattern);
        }

        public void setHeadScope(Scope scope)
        {
            headScope = scope;
        }

        public Scope getHeadScope()
        {
            return headScope;
        }

        public void setHeadPurpose(Purpose purpose)
        {
            headPurpose = purpose;
        }

        public Purpose getHeadPurpose()
        {
            return headPurpose;
        }
    }
}
