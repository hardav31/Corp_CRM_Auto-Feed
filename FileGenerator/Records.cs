using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileGenerator
{
    public class Records
    {
        public List<Project> Projects { get; set; }
        [XmlArray("Teams")]
        [XmlArrayItem("Team")]
        public List<SerializableTeam> xTeams { get; set; }
    }
}
