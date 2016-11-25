using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Models
{
        public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<Member> Members;

        public Team()
        {
            Members = new List<Member>();
        }
        public Team(int teamId, string teamName)
        {
            TeamID = teamId;
            TeamName = teamName;
            Members = new List<Member>();
        }
    }
}
