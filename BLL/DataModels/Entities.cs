using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Entities
    {
        public string TeamId { get; set; }
        public string TeamName {get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCreatedDate { get; set; }
        public string ProjectDueDate { get; set; }
        public string ProjectDescription { get; set; }
        public Entities()
        {; }

        public Entities(string teamid, string teamname,string memberid, string membername, string membersurname, string projectid, string projectduedate, string projectdescription, string projectname, string projectcreateddate)
        {
            TeamId = teamid;
            TeamName = teamname;
            MemberId = memberid;
            MemberName = membername;
            MemberSurname = membername;
            ProjectId = projectid;
            ProjectDueDate = projectduedate;
            ProjectDescription = projectdescription;
            ProjectName = projectname;
            ProjectCreatedDate = projectcreateddate;
        }
    }
}
