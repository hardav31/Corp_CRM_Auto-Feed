﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FileGenerator.Models
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

        public List<Project> Projects = new List<Project>();
        public Member(int memberId, string memberName, string memberSurname)
        {
            MemberID = memberId;
            MemberName = memberName;
            MemberSurname = memberSurname;
        }
        public Member()
        {

        }
    }
}
