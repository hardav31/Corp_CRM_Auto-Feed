using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FileGenerator
{
    [Serializable]
    public class SerializableTeam
    {
        [XmlAttribute]
        public int TeamID { get; set; }
        [XmlAttribute]
        public string TeamName { get; set; }
        [XmlArrayItem("Member")]
        public List<SerializableMember> Members;

        public SerializableTeam()
        {

        }
        public SerializableTeam(int teamId, string teamName)
        {
            TeamID = teamId;
            TeamName = teamName;
            Members = new List<SerializableMember>();
        }
    }
}
