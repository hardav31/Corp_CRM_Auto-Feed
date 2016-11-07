using Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataManager
{
    class DTable :IDisposable
    {
        DataTable dt = new DataTable();
        public DataTable Create() 
        {
            dt.Columns.Add("MemberID", typeof(int));
            dt.Columns.Add("MemberName", typeof(string));
            dt.Columns.Add("MemberSurname", typeof(string));
            dt.Columns.Add("TeamID", typeof(int));
            dt.Columns.Add("TeamName", typeof(string));
            dt.Columns.Add("ProjectID", typeof(int));
            dt.Columns.Add("ProjectName", typeof(string));
            dt.Columns.Add("ProjectCreatedDate", typeof(DateTime));
            dt.Columns.Add("ProjectDueDate", typeof(DateTime));
            dt.Columns.Add("ProjecDescription", typeof(string));
            return dt;
        }


        public DataTable Fill(DataTable dt, Dictionary<int, Team> teamsD)
        {
            foreach (var team in teamsD)
            {
                foreach (var member in team.Value.Members)
                {
                    foreach (var project in member.Projects)
                    {
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = new object[]{
                            member.MemberID, member.MemberName,member.MemberSurname,
                            team.Value.TeamID, team.Value.TeamName,
                            project.ProjectID,project.ProjectName,project.ProjectCreatedDate,project.ProjectDueDate,project.ProjectDescription
                         };

                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
        public void Dispose()
        {
           dt.Dispose();
        }
    }
}
