using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FileGenerator
{
    [Serializable]
    public class xTeam
    {
        [XmlAttribute]
        public int TeamID { get; set; }
        [XmlAttribute]
        public string TeamName { get; set; }
        [XmlArrayItem("Member")]
        public List<xMember> Members;

        public xTeam()
        {

        }
        public xTeam(int teamId, string teamName)
        {
            TeamID = teamId;
            TeamName = teamName;
            Members = new List<xMember>();
        }
    }
}
