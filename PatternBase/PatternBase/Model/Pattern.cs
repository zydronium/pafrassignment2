using PatternBase.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    public class Pattern : ComponentModel
    {
        public string problem;
        public string solution;
        public string consequence;
        public List<Ids> hasPurpose = new List<Ids>();
        public List<Ids> hasScope = new List<Ids>();

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
            List<Purpose> list = new List<Purpose>();
            foreach (Ids purp in hasPurpose)
            {
                list.Add(Program.database.getPurposeById(purp.id));
            }
            return list;
        }

        public void setPurposeList(List<Purpose> plist)
        {
            hasPurpose = new List<Ids>();
            foreach (Purpose purp in plist)
            {
                addPurpose(purp);
            }
        }

        public Purpose getPurpose(string purposeName)
        {
            List<Purpose> list = getPurposeList();
            foreach (Purpose purp in list)
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
            Ids ids = new Ids();
            ids.id = purp.getId();
            hasPurpose.Add(ids);
        }

        public void removePurpose(Scope purp)
        {
            foreach (Ids ids in hasPurpose)
            {
                if (purp.getId() == ids.id)
                {
                    hasPurpose.Remove(ids);
                }
            }
        }

        public void cleanPurpose()
        {
            hasPurpose = new List<Ids>();
        }

        public List<Scope> getScopeList()
        {
            List<Scope> list = new List<Scope>();
            foreach (Ids sco in hasScope)
            {
                list.Add(Program.database.getScopeById(sco.id));
            }
            return list;
        }

        public void setScopeList(List<Scope> sclist)
        {
            hasScope = new List<Ids>();
            foreach (Scope sco in sclist)
            {
                addScope(sco);
            }
        }

        public Scope getScope(string scName)
        {
            List<Scope> list = getScopeList();
            foreach (Scope scope in list)
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
            Ids ids = new Ids();
            ids.id = scope.getId();
            hasScope.Add(ids);
        }

        public void removeScope(Scope scope)
        {
            foreach (Ids ids in hasScope)
            {
                if (scope.getId() == ids.id)
                {
                    hasScope.Remove(ids);
                }
            }
        }

        public void cleanScope()
        {
            hasScope = new List<Ids>();
        }
    }

}
