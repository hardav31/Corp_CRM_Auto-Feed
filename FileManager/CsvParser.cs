using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;
using LogManager;
using App_Configuration;
using Pbar;

namespace FileManager
{
    class CsvParser
    {
        private static readonly Lazy<CsvParser> lazy = new Lazy<CsvParser>(() => new CsvParser());
        public static CsvParser csvParserObj { get { return lazy.Value; } }
        private CsvParser()
        {
        }

        public void CSVFileReader(string direction)
        {
            string fileName = Path.GetFileName(direction);
            int i = 1;
            int team_Id;
            int member_Id;
            int project_Id;
            Dictionary<int, Team> TeamsD = new Dictionary<int, Team>();
            Dictionary<int, Member> MembersD = new Dictionary<int, Member>();
            Dictionary<int, Project> ProjectsD = new Dictionary<int, Project>();
            bool new_team;
            bool new_member;
            bool new_projecr;
            bool IsAllRight = true;
            try
            {
                foreach (var e in File.ReadAllLines(direction).Where(line => !string.IsNullOrEmpty(line)).Skip(1))
                {
                    i++;
                    string[] line = e.Split(',');

                    if (line.Length != 10)
                    {
                        LoggerType.WriteToLog(LogType.Warning, fileName, i.ToString());
                        IsAllRight = false;
                        break;
                    }


                    if (Array.Exists(line, s => string.IsNullOrEmpty(s)))
                    {
                        LoggerType.WriteToLog(LogType.Warning, fileName, i.ToString());
                        IsAllRight = false;
                        break;
                    }

                    if (!int.TryParse(line[0], out team_Id) || team_Id < 0)
                    {
                        LoggerType.WriteToLog(LogType.Error, fileName, i.ToString());
                        IsAllRight = false;
                        break;
                    }

                    if (!int.TryParse(line[2], out member_Id) || member_Id < 0)
                    {
                        LoggerType.WriteToLog(LogType.Error, fileName, i.ToString());
                        IsAllRight = false;
                        break;
                    }

                    if (!int.TryParse(line[5], out project_Id) || project_Id < 0)
                    {
                        LoggerType.WriteToLog(LogType.Error, fileName, i.ToString());
                        IsAllRight = false;
                        break;
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


                    if (!MembersD[member_Id].Projects.Exists(p => p.ProjectID == project_Id))
                    {
                        MembersD[member_Id].Projects.Add(ProjectsD[project_Id]);
                    }

                    if (!TeamsD[team_Id].Members.Exists(m => m.MemberID == member_Id))
                    {
                        TeamsD[team_Id].Members.Add(MembersD[member_Id]);
                    }
                }
              
                if (IsAllRight)
                {
                    if (AppConfigManager.appSettings.SaveInJson)
                    {
                        FileConverter.fileConverter.ConverToJson(TeamsD, ProjectsD, direction);
                    }
                    if (AppConfigManager.appSettings.SaveInDB)
                    {
                        FileConverter.fileConverter.StoreInDB(TeamsD);
                    }
                }

            }


            catch (Exception ex)
            {
                IsAllRight = false;
                LoggerType.WriteToLog(Path.GetFileName(direction), ex);
            }

            finally
            {
                if (!IsAllRight)
                {
                    File.Move(direction, AppConfigManager.appSettings.WrongFilePath + direction.AppendTimeStamp());
                    LoggerType.WriteToLog(LogType.Info, fileName, " was moved to Wrong Files folder");
                }
                else
                {
                    LoggerType.WriteToLog(LogType.Info, " Data was successfully saved", fileName);
                    File.Delete(direction);
                    ProgressBar.Print($"{ fileName} file was deleted at {DateTime.Now}");
                }
            }
        }

    }
}
