using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FileGenerator.Models
{

    [Serializable]

    public class Team
    {
        [XmlAttribute]
        public int TeamID { get; set; }
        [XmlAttribute]
        public string TeamName { get; set; }

        public List<Member> Members = new List<Member>();
        public Team(int teamId, string teamName)
        {
            TeamID = teamId;
            TeamName = teamName;
        }
        public Team()
        {

        }

        public override string ToString()
        {
            return TeamID + "," + TeamName;
        }

    }
}
