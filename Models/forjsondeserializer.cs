using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //FOR TESTING JSON SERIALIZER?DESERIALIZER
    public class forjsondeserializer
    {
        public List<Team> team { get; set; }
        public List<Project> project { get; set; }
        public forjsondeserializer(List<Team> t, List<Project> p)
        {
            team = t;
            project = p;
        }
    }
}
