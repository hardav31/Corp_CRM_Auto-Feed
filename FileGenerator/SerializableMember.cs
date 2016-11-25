using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FileGenerator
{
    [Serializable]
    public class SerializableMember
    {
        [XmlAttribute]
        public int MemberID { get; set; }
        [XmlAttribute]
        public string MemberName { get; set; }
        [XmlAttribute]
        public string MemberSurname { get; set; }

        [XmlElement("ProjectID")]
        public List<int> ProjectIDs;

        public SerializableMember()
        {

        }
        public SerializableMember(int memberId, string memberName, string memberSurname)
        {
            MemberID = memberId;
            MemberName = memberName;
            MemberSurname = memberSurname;
            ProjectIDs = new List<int>();
        }
    }
}
