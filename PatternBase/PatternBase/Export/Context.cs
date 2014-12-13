using PatternBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Export
{
    class Context
    {
        private IExport exportInterface;
 
        //Constructor: assigns strategy to interface
        public Context(IExport strategy)
        {
            this.exportInterface = strategy;
        }
 
        //Executes the strategy
        public void SaveDatabase(string location, Database database)
        {
            exportInterface.SaveDatabase(location, database);
        }

        //Executes the strategy
        public Database OpenDatabase(string location)
        {
            return exportInterface.OpenDatabase(location);
        }
    }
}
