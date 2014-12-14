using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public class Pattern
    {
        public string name;
        public string description;
        public int id;
        public string context;
        public string problem;
        public string solution;
        public string consequence;
        public List<Purpose> hasPurpose = new List<Purpose>();
        public List<Scope> hasScope = new List<Scope>();

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

        public string getContext() 
        {
            return context;
        }

        public void setContext(string ctxt)
        {
            context = ctxt;
        }

        public string getProblem()
        {
            return problem;
        }

        public void setProblem(string prob)
        {
            problem = prob;
        }

        public string getSolution()
        {
            return solution;
        }

        public void setSolution(string sol)
        {
            solution = sol;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string descr)
        {
            description = descr;
        }

        public string getConsequence()
        {
            return consequence;
        }

        public void setConsequence(string cons)
        {
            consequence = cons;
        }

        public List<Purpose> getPurposeList()
        {
            return hasPurpose;
        }

        public void setPurposeList(List<Purpose> plist)
        {
            hasPurpose = plist;
        }

        public Purpose getPurpose(string purposeName)
        {
            foreach (Purpose purp in hasPurpose)
            {
                if (purp.getName() == purposeName)
                {
                    return purp;
                }
            }
            return null;
        }

        public void addPurpose(Purpose purp)
        {
            hasPurpose.Add(purp);
        }

        public void removePurpose(Purpose purp)
        {
            hasPurpose.Remove(purp);
        }

        public List<Scope> getScopeList()
        {
            return hasScope;
        }

        public void setScopeList(List<Scope> sclist)
        {
            hasScope = sclist;
        }

        public Scope getScope(string scName)
        {
            foreach (Scope scope in hasScope)
            {
                if (scope.getName() == scName)
                {
                    return scope;
                }
            }
            return null;
        }

        public void addScope(Scope scope)
        {
            hasScope.Add(scope);
        }

        public void removeScope(Scope scope)
        {
            hasScope.Remove(scope);
        }


    }

}
