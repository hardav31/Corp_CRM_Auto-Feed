using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //FOR TESTING JSON SERIALIZER/DESERIALIZER
    public class forjson
    {
        public List<Team> Teams { get; set; }
        public List<Project> Projects { get; set; }
        public forjson(List<Team> t, List<Project> p)
        {
            Teams = t;
            Projects = p;
        }
    }
}
