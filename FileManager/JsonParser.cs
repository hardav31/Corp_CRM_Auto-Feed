using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class JsonParser
    {
        public string FilePath;

        public string jsonFoldername(string filepath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_");
            sb.Append(filepath.Substring(filepath.LastIndexOf('\\') + 1, filepath.Length - filepath.LastIndexOf('\\') - 1));
            return sb.ToString();
        }

        public void JsonWrite(Dictionary<int, Team> teamlist)
        {
            int teamCount, memberCount, projectCount;

            StringBuilder jsonrow = new StringBuilder();

            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(FilePath, FileMode.Create)))
                {
                    sw.WriteLine("{");
                    sw.WriteLine("\"Team\":");
                    sw.WriteLine("\t[");
                    teamCount = teamlist.Values.Count;
                    foreach (Team teams in teamlist.Values)
                    {
                        teamCount--;
                        jsonrow.Clear();
                        jsonrow.AppendLine("\t  {");
                        jsonrow.AppendLine("\t    \"TeamID\":" + teams.TeamID + ",");
                        jsonrow.AppendLine("\t    \"TeamName:\"" + teams.TeamName + "\",");
                        jsonrow.AppendLine("\t    \"Member\":");
                        jsonrow.AppendLine("\t\t[");

                        memberCount = teams.Members.Count;
                        foreach (Member members in teams.Members)
                        {
                            memberCount--;
                            jsonrow.AppendLine("\t\t  {");
                            jsonrow.AppendLine("\t\t    \"MemberID\":" + members.MemberID + ",");
                            jsonrow.AppendLine("\t\t    \"MemberName\":" + "\"" + members.MemberName + "\",");
                            jsonrow.AppendLine("\t\t    \"MemberSurname\":" + "\"" + members.MemberSurname + "\",");
                            jsonrow.AppendLine("\t\t    \"Project\":");
                            jsonrow.AppendLine("\t\t\t[");

                            projectCount = members.Projects.Count;
                            foreach (Project projects in members.Projects)
                            {
                                projectCount--;
                                jsonrow.AppendLine("\t\t\t  {");
                                jsonrow.AppendLine("\t\t\t    \"ProjectID:" + projects.ProjectID + ",");
                                jsonrow.AppendLine("\t\t\t    \"ProjectName:" + "\"" + projects.ProjectName + "\",");
                                jsonrow.AppendLine("\t\t\t    \"ProjectDescription:" + "\"" + projects.ProjectDescription + "\",");
                                jsonrow.AppendLine("\t\t\t    \"ProjectCreatedDate:" + "\"" + projects.ProjectCreatedDate + "\",");
                                jsonrow.AppendLine("\t\t\t    \"ProjectDueDate:" + "\"" + projects.ProjectDueDate + "\"");

                                if (projectCount != 0)
                                {
                                    jsonrow.AppendLine("\t\t\t  },");
                                }
                                else
                                {
                                    jsonrow.AppendLine("\t\t\t  }");
                                }

                            }

                            jsonrow.AppendLine("\t\t\t]");

                            if (memberCount != 0)
                            {
                                jsonrow.AppendLine("\t\t  },");
                            }
                            else
                            {
                                jsonrow.AppendLine("\t\t  }");
                            }
                        }
                        jsonrow.AppendLine("\t\t]");
                        if (teamCount != 0)
                        {
                            jsonrow.AppendLine("\t  },");
                        }
                        else
                        {
                            jsonrow.AppendLine("\t  }");
                        }

                        sw.Write(jsonrow);
                    }
                    sw.WriteLine("\t]");
                    sw.WriteLine("}");

                }

            }
            catch (DirectoryNotFoundException e)
            {
                //TODO: Loging
                Console.WriteLine("Directore where must be writing data in Json format not found");
            }
            catch (UnauthorizedAccessException e)
            {
                //TODO: Loging
                Console.WriteLine("You don't have enought access to the directore where must be writing data in Json format");
            }
            catch (IOException e)
            {
                //TODO: Loging
                Console.WriteLine("You don't have enought access to the directore where must be writing data in Json format");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //TODO: Loging
                Console.WriteLine("There were some problems during parsing data to JSON, for more information please the application log");
            }
        }
    }
}

