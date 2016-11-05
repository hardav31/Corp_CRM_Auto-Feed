using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;
using System.Text;
using System.Configuration;
using LogManager;

namespace FileManager
{
    class CsvParser
    {

        public void CSVFileReader(string direction)
        {
            int i = 0;
            int team_Id;
            int member_Id;
            int project_Id;
            Dictionary<int, Team> TeamsD = new Dictionary<int, Team>();
            Dictionary<int, Member> MembersD = new Dictionary<int, Member>();
            Dictionary<int, Project> ProjectsD = new Dictionary<int, Project>();
            bool new_team;
            bool new_member;
            bool new_projecr;
            try
            {
                foreach (var e in File.ReadAllLines(direction).Where(line => !string.IsNullOrEmpty(line)))
                {
                    i++;
                    string[] line = e.Split(',');

                    if (line.Length != 10)
                    {
                        Log.DoLog(Chois.Warning, direction, i.ToString());
                        continue;
                    }


                    if (Array.Exists(line, s => string.IsNullOrEmpty(s)))
                    {
                        //TODO:log
                        continue;
                    }

                    if (!int.TryParse(line[0], out team_Id))
                    {
                        Log.DoLog(Chois.Error, direction, i.ToString());
                        continue;
                    }

                    if (!int.TryParse(line[2], out member_Id))
                    {
                        //TODO:log
                        continue;
                    }

                    if (!int.TryParse(line[5], out project_Id))
                    {
                        //TODO:log
                        continue;
                    }


                    if (new_team = (!TeamsD.ContainsKey(team_Id)))
                    {
                        TeamsD.Add(team_Id, new Team(team_Id, line[1]));
                    }

                    if (new_member = (!MembersD.ContainsKey(member_Id)))
                    {
                        MembersD.Add(member_Id, new Member(member_Id, line[3], line[4]));
                    }

                    if (new_projecr = (!ProjectsD.ContainsKey(project_Id)))
                    {
                        ProjectsD.Add(project_Id, new Project(project_Id, line[6], DateTime.Parse(line[7]), DateTime.Parse(line[8]), line[9]));
                    }

                    // Checking duplicate rows
                    if ((!new_member && !new_team) && (!new_projecr))
                    {
                        if (MembersD[member_Id].Projects.Contains(ProjectsD[project_Id]))
                        {
                            continue;
                        }
                    }

                    // Checking if member is part of only one team
                    if ((new_team) && (!new_member))
                    {
                        //TODO:log
                        continue;
                    }

                    if (!MembersD[member_Id].Projects.Exists(p => p.ProjectID == project_Id))
                    {
                        MembersD[member_Id].Projects.Add(ProjectsD[project_Id]);
                    }

                    if (!TeamsD[team_Id].Members.Exists(m => m.MemberID == member_Id))
                    {
                        TeamsD[team_Id].Members.Add(MembersD[member_Id]);
                    }
                }

                StringBuilder sb = new StringBuilder();
                JsonParser jsParser = new JsonParser();
                jsParser.FilePath = sb.Append(@ConfigurationManager.AppSettings["JSONFolderForCSV"] + jsParser.jsonFoldername(direction)).ToString();
                jsParser.JsonWrite(TeamsD);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                ProjectsD = null;
                MembersD = null;
                Console.WriteLine(i);
            }


            CreateDS cds = new CreateDS();
            cds.DS(TeamsD);
        }
      
       //TODO: Invoke Json or Saving Data in DB methods
    }
}
