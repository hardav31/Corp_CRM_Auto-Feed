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
        [XmlArray("Teams")]
        [XmlArrayItem("Team")]
        public List<xTeam> xTeams { get; set; }
        public List<Project> Projects { get; set; }
    }
}
