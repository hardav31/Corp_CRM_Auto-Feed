using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataUpdater
    {
        public void Update(Dictionary<int, Team> teamsD)
        {
            DataTableCreator dtcreator = new DataTableCreator();
            DataTable dt = dtcreator.Create();

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
            try
            {
                using (DBConnection dbcon = new DBConnection())
                {
                    SqlCommand cmd = dbcon.getCommand("dbo.insertData", "@sourcetable", dt, CommandType.StoredProcedure);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
            }
            
            
        }
    }
}
