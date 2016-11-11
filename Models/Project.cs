using System;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public class Project
    {
        [XmlAttribute]
        public int ProjectID { get; set; }
        [XmlAttribute]
        public string ProjectName { get; set; }
        [XmlAttribute]
        public DateTime ProjectCreatedDate { get; set; }
        [XmlAttribute]
        public DateTime ProjectDueDate { get; set; }
        [XmlAttribute]
        public string ProjectDescription { get; set; }

        public Project()
        {

        }
        public Project(int projectId, string projectName, DateTime projectCreatedDate, DateTime projectDueDate, string projectDescription)
        {
            ProjectID = projectId;
            ProjectName = projectName;
            ProjectCreatedDate = projectCreatedDate;
            ProjectDueDate = projectDueDate;
            ProjectDescription = projectDescription;
        }
    }
}