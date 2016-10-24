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
        public Team(int teamId, string teamName, Member member)
        {
            TeamID = teamId;
            TeamName = teamName;
            Members.Add(member);

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
