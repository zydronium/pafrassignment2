using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public class Database
    {
        public List<Scope> scopes = new List<Scope>();
        public List<Purpose> purposes = new List<Purpose>();
        public List<Pattern> patterns = new List<Pattern>();

        public Scope headScope;
        public Purpose headPurpose;
        public int id;

        public int getId()
        {
            id++;
            return id;
        }

        public List<Scope> getScopeList()
        {
            return scopes;
        }

        public void setScopeList(List<Scope> sclist)
        {
            scopes = sclist;
        }

        public Scope getScope(string sName)
        {
            foreach (Scope scope in scopes)
            {
                if (scope.getName() == sName)
                {
                    return scope;
                }
            }
            return null;
        }

        public Scope getScopeById(int id)
        {
            foreach (Scope scope in scopes)
            {
                if (scope.getId() == id)
                {
                    return scope;
                }
            }
            return null;
        }

        public void addScope(Scope scope)
        {
            scopes.Add(scope);
        }

        public void removeScope(Scope scope)
        {
            scopes.Remove(scope);
        }

        public List<Purpose> getPurposeList()
        {
            return purposes;
        }

        public void setPurposeList(List<Purpose> purlist)
        {
            purposes = purlist;
        }

        public Purpose getPurpose(string pName)
        {
            foreach (Purpose purpose in purposes)
            {
                if (purpose.getName() == pName)
                {
                    return purpose;
                }
            }
            return null;
        }

        public Purpose getPurposeById(int id)
        {
            foreach (Purpose purpose in purposes)
            {
                if (purpose.getId() == id)
                {
                    return purpose;
                }
            }
            return null;
        }

        public void addPurpose(Purpose purpose)
        {
            purposes.Add(purpose);
        }

        public void removePurpose(Purpose purpose)
        {
            purposes.Remove(purpose);
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
