using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class CreateDS
    {
        public void DS(Dictionary<int, Team> teamsD)
        {
            List<Team> teams = new List<Team>();
            foreach (var item in teamsD)
            {
                teams.Add(item.Value);
            }

            DataTable dt = new DataTable();
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
            int i = 0;
            foreach (var team in teams)
            {
                foreach (var member in team.Members)
                {
                    foreach (var project in member.Projects)
                    {
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = new object[]{
                            member.MemberID, member.MemberName,member.MemberSurname,
                            team.TeamID, team.TeamName,
                            project.ProjectID,project.ProjectName,project.ProjectCreatedDate,project.ProjectDueDate,project.ProjectDescription
                         };
                        dt.Rows.Add(dr); 

                    }
                }
                i++;
                if (i == 10) break;


            }
            //for (int i = 0; i < 2; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr.ItemArray = new object[]
            //    {
            //                teams[i].Members[i].MemberID, teams[i].Members[i].MemberName,teams[i].Members[i].MemberSurname,
            //                teams[i].TeamID, teams[i].TeamName,
            //                teams[i].Members[i].Projects[i].ProjectID, teams[i].Members[i].Projects[i].ProjectName, teams[i].Members[i].Projects[i].ProjectCreatedDate, teams[i].Members[i].Projects[i].ProjectDueDate, teams[0].Members[0].Projects[0].ProjectDescription
            //     };
            //    dt.Rows.Add(dr);
            //}

            SqlConnection con = new SqlConnection(@"Data Source=tcp:micinternship.database.windows.net,1433; Initial Catalog = praemium1;Persist Security Info=True;User ID=mic;Password=Admin.Pa$$");
            SqlCommand cmd = new SqlCommand("dbo.insertData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param.ParameterName = @"@sourcetable";
            param.Value = dt;
            cmd.Parameters.Add(param);
           // cmd.CommandTimeout = 0;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("success");
        }
    }
}