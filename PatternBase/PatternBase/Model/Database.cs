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
        public int id;

        public int getId()
        {
            id++;
            return id;
        }

        public Scope getScopeById(int id)
        {
            List<Scope> scopes = new List<Scope>();

            scopes = fetchSubCategories(headScope, scopes);

            foreach (Scope scope in scopes)
            {
                if (scope.getId() == id)
                {
                    return scope;
                }
            }
            return null;
        }

        public Purpose getPurposeById(int id)
        {
            List<Purpose> purposes = new List<Purpose>();

            purposes = fetchSubCategories(headPurpose, purposes);

            foreach (Purpose purpose in purposes)
            {
                if (purpose.getId() == id)
                {
                    return purpose;
                }
            }
            return null;
        }

        private List<Scope> fetchSubCategories(Scope sco, List<Scope> values)
        {
            values.Add(sco);
            foreach (ComponentModel sc in sco.getSubComponents())
            {
                if (sc.GetType() == typeof(Scope))
                {
                    values = this.fetchSubCategories((Scope)sc, values);
                }
            }
            return values;
        }

        private List<Purpose> fetchSubCategories(Purpose purp, List<Purpose> values)
        {
            values.Add(purp);
            foreach (ComponentModel pur in purp.getSubComponents())
            {
                if (pur.GetType() == typeof(Purpose))
                {
                    values = this.fetchSubCategories((Purpose)pur, values);
                }
            }
            return values;
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
