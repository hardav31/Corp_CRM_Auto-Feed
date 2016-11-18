using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace FileManager
{
    class JsonParser
    {
        private static readonly Lazy<JsonParser> lazy = new Lazy<JsonParser>(() => new JsonParser());
        public static JsonParser JsonParserObject { get { return lazy.Value; } }
        private JsonParser()
        {
        }
        public string FilePath;
        Dictionary<int, Project> projectD = new Dictionary<int, Project>();

        public void JsonSerializer(Dictionary<int, Team> teamlist,Dictionary<int, Project> projectlist)
        {
            int teamCount, memberCount, projectCount;
            StringBuilder jsonrow = new StringBuilder();

            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(FilePath, FileMode.Create)))
                {
                    sw.WriteLine("{");
                    sw.WriteLine("\"Teams\":");
                    sw.WriteLine("\t[");
                    teamCount = teamlist.Values.Count;
                    foreach (Team teams in teamlist.Values)
                    {
                        teamCount--;
                        jsonrow.Clear();
                        jsonrow.AppendLine("\t  {");
                        jsonrow.AppendLine("\t    \"TeamID\":" + teams.TeamID + ",");
                        jsonrow.AppendLine("\t    \"TeamName\":" + "\""+ teams.TeamName + "\",");
                        jsonrow.AppendLine("\t    \"Members\":");
                        jsonrow.AppendLine("\t\t[");

                        memberCount = teams.Members.Count;
                        foreach (Member members in teams.Members)
                        {
                            memberCount--;
                            jsonrow.AppendLine("\t\t  {");
                            jsonrow.AppendLine("\t\t    \"MemberID\":" + members.MemberID + ",");
                            jsonrow.AppendLine("\t\t    \"MemberName\":" + "\"" + members.MemberName + "\",");
                            jsonrow.AppendLine("\t\t    \"MemberSurname\":" + "\"" + members.MemberSurname + "\",");
                            jsonrow.AppendLine("\t\t    \"Projects\":");
                            jsonrow.AppendLine("\t\t\t[");

                            projectCount = members.Projects.Count;
                            foreach (Project projects in members.Projects)
                            {
                                projectCount--;
                                jsonrow.AppendLine("\t\t\t  {");
                                jsonrow.AppendLine("\t\t\t    \"ProjectID\":" + projects.ProjectID);
                             
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
                    sw.WriteLine("\t],");
                    jsonrow.Clear();
                    sw.WriteLine("\"Projects\":");
                    sw.WriteLine("\t[");
                    projectCount = projectlist.Values.Count;
                    foreach (Project item in projectlist.Values)
                    {
                        projectCount--;
                        jsonrow.Clear();
                        jsonrow.AppendLine("\t  {");
                        jsonrow.AppendLine("\t    \"ProjectID\":" + item.ProjectID + ",");
                        jsonrow.AppendLine("\t    \"ProjectName\":" + "\""+ item.ProjectName + "\",");
                        jsonrow.AppendLine("\t    \"ProjectDescription\":" + "\""+item.ProjectDescription + "\",");
                        jsonrow.AppendLine("\t    \"ProjectCreatedDate\":" + "\""+ item.ProjectCreatedDate + "\",");
                        jsonrow.AppendLine("\t    \"ProjectDueDate\":" + "\""+ item.ProjectDueDate + "\"");

                        if (projectCount != 0)
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
                throw e;
            }
            catch (UnauthorizedAccessException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

