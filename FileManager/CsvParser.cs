﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;
using System.Text;
using LogManager;
using DataManager;
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
            bool IsAllRight = true;
            try
            {
                foreach (var e in File.ReadAllLines(direction).Where(line => !string.IsNullOrEmpty(line)).Skip(1))
                {
                    i++;
                    string[] line = e.Split(',');

                    if (line.Length != 10)
                    {
                        LoggerType.Warning(Path.GetFileName(direction), i.ToString());
                        IsAllRight = false;
                        break;
                    }


                    if (Array.Exists(line, s => string.IsNullOrEmpty(s)))
                    {
                        LoggerType.Warning(Path.GetFileName(direction), i.ToString());
                        IsAllRight = false;
                        break;
                    }

                    if (!int.TryParse(line[0], out team_Id))
                    {
                        LoggerType.Error(Path.GetFileName(direction), i.ToString());
                        IsAllRight = false;
                        break;
                    }

                    if (!int.TryParse(line[2], out member_Id))
                    {
                        LoggerType.Error(Path.GetFileName(direction), i.ToString());
                        IsAllRight = false;
                        break;
                    }

                    if (!int.TryParse(line[5], out project_Id))
                    {
                        LoggerType.Error(Path.GetFileName(direction), i.ToString());
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

                    // Checking if member is part of only one team
                    // Sql abdate
                    //if ((new_team) && (!new_member))
                    //{
                    //    //TODO:log
                    //    continue;
                    //}

                    if (!MembersD[member_Id].Projects.Exists(p => p.ProjectID == project_Id))
                    {
                        MembersD[member_Id].Projects.Add(ProjectsD[project_Id]);
                    }

                    if (!TeamsD[team_Id].Members.Exists(m => m.MemberID == member_Id))
                    {
                        TeamsD[team_Id].Members.Add(MembersD[member_Id]);
                    }
                }

                MembersD = null;
                ProjectsD = null;
                
                if(IsAllRight)
                {
                    if (AppConfigManager.appSettings.SaveInJson)
                    {
                        StringBuilder sb = new StringBuilder();
                        JsonParser jsParser = new JsonParser();
                        jsParser.FilePath = sb.Append(AppConfigManager.appSettings.JsonFolder_forCsv + jsParser.jsonFoldername(direction)).ToString();
                        jsParser.JsonWrite(TeamsD);
                        LoggerType.Info(Path.GetFileName(direction), "Json Success");
                    }
                    if (AppConfigManager.appSettings.SaveInDB)
                    {
                        DataUpdater dUpdater = new DataUpdater();
                        dUpdater.UpdateData(TeamsD);
                        LoggerType.Info(Path.GetFileName(direction), "DB Success");
                    }
                }

               
            }
           

            catch (Exception ex)
            {
                LoggerType.Exceptin(Path.GetFileName(direction), ex);                
            }

            finally
            {
                if (!IsAllRight)
                {
                    File.Move(direction, AppConfigManager.appSettings.WrongFilePath + Path.GetFileName(direction));
                    ProgressBar.Print("___________________________________________________________--");
                }
                else
                {
                    File.Delete(direction);
                }
            }
        }

    }
}
