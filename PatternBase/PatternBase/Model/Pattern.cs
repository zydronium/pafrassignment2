using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    class Pattern
    {
        public string name;
        public string context;
        public string problem;
        public string solution;
        public string description;
        public string consequence;
        public Purpose hasPurpose;
        public List<Scope> hasScope = new List<Scope>();
    }
}
