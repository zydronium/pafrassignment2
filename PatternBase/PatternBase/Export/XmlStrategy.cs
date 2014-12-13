using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternBase.Model;

namespace PatternBase.Export
{
    class XmlStrategy : IExport
    {
        public void SaveDatabase(string location, Database database)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Database));

            System.IO.StreamWriter file = new System.IO.StreamWriter(location);
            writer.Serialize(file, database);
            file.Close();
        }

        public Database OpenDatabase(string location)
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Database));
            System.IO.StreamReader file = new System.IO.StreamReader(location);
            Database database = (Database)reader.Deserialize(file);

            return database;
        }
    }
}
