using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Models
{

    [Serializable]

    public class Team
    {
        [XmlAttribute]
        public int TeamID { get; set; }
        [XmlAttribute]
        public string TeamName { get; set; }
        public List<Member> Members;

        public Team()
        {

        }
        public Team(int teamId, string teamName)
        {
            TeamID = teamId;
            TeamName = teamName;
            Members = new List<Member>();
        }
    }
}
