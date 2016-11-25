using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.XmlConfiguration;

namespace Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public List<Project> Projects;

        public Member()
        {
            Projects = new List<Project>();
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
