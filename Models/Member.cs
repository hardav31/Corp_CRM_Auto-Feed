using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public class Member
    {
        [XmlAttribute]
        public int MemberID { get; set; }
        [XmlAttribute]
        public string MemberName { get; set; }
        [XmlAttribute]
        public string MemberSurname { get; set; }
        public List<Project> Projects;

        public Member()
        {

        }
        public Member(int memberId, string memberName, string memberSurname)
        {
            MemberID = memberId;
            MemberName = memberName;
            MemberSurname = memberSurname;
            Projects = new List<Project>();


        }
    }
}
