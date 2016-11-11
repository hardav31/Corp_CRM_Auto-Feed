using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Models;
using System.IO;
using System.Text;
using App_Configuration;
using DataManager;
using Pbar;
using LogManager;

namespace FileManager
{
    class XMLParser
    {
        private static readonly Lazy<XMLParser> lazy = new Lazy<XMLParser>(() => new XMLParser());
        public static XMLParser xmlParserObj { get { return lazy.Value; } }
        private XMLParser()
        {
        }

        public void XMLFileReader(string direction)
        {
            bool IsAllRight = true;
            Dictionary<int, Team> TeamsD = new Dictionary<int, Team>();
            Dictionary<int, char> MembersD = new Dictionary<int, char>(); // for compare all Member's id
            Dictionary<int, char> ProjectsD = new Dictionary<int, char>(); // for compare Project's id in one Member
            try
            {
                Team current_Team = null;
                Member current_Member = null;
                Project current_Project = null;

                int Teamattributecount = 2;
                int Memberattributecount = 3;
                int Projectattributecount = 5;


                using (XmlTextReader xml = new XmlTextReader(direction))
                {
                    ProgressBar.Print("XmlOpen " + DateTime.Now);
                    while (xml.Read())
                    {
                        switch (xml.NodeType)
                        {
                            case XmlNodeType.Element:
                                #region Team
                                if (xml.Name == "Team")
                                {
                                    current_Team = new Team() { Members=new List<Member>() };

                                    if (xml.AttributeCount != Teamattributecount)
                                    {
                                        Teamattributecount = 0;
                                        IsAllRight = false;
                                    }
                                    for (int i = 0; i < Teamattributecount; i++)
                                    {
                                        if (xml.GetAttribute(i) != "")
                                        {
                                            if (i == 0)
                                            {
                                                    int x;
                                                    IsAllRight = Int32.TryParse(xml.GetAttribute(i), out x);
                                                if (x > 0)
                                                {
                                                    current_Team.TeamID = x;
                                                }
                                                else
                                                {
                                                    IsAllRight = false;
                                                }
                                            }
                                            if (i == 1)
                                            {
                                                current_Team.TeamName = xml.GetAttribute(i);
                                            }

                                        }
                                        else
                                        {
                                            IsAllRight = false;
                                            break;
                                        }
                                    }
                                    if (IsAllRight && !TeamsD.Keys.Contains(current_Team.TeamID))
                                    {
                                        TeamsD[current_Team.TeamID] = current_Team;
                                    }
                                    else
                                    {
                                        LoggerType.Error(Path.GetFileName(direction), xml.LineNumber.ToString());
                                        xml.Skip();
                                    }
                                }
                                #endregion
                                #region Member
                                if (xml.Name == "Member")
                                {
                                    current_Member = new Member() { Projects=new List<Project>() };
                                    if (xml.AttributeCount != Memberattributecount)
                                    {
                                        Memberattributecount = 0;
                                        IsAllRight = false;
                                    }

                                    for (int i = 0; i < Memberattributecount; i++)
                                    {
                                        if (xml.GetAttribute(i) != "")
                                        {
                                            if (i == 0)
                                            {
                                                    int x;
                                                    IsAllRight = Int32.TryParse(xml.GetAttribute(i), out x);
                                                if (x > 0)
                                                {
                                                    current_Member.MemberID = x;
                                                }
                                                else
                                                {
                                                    IsAllRight = false;
                                                }

                                            }
                                            if (i == 1)
                                            {
                                                current_Member.MemberName = xml.GetAttribute(i);
                                            }
                                            if (i == 2)
                                            {
                                                current_Member.MemberSurname = xml.GetAttribute(i);
                                            }
                                        }
                                        else
                                        {
                                            IsAllRight=false;
                                            break;
                                        }
                                    }
                                    if (IsAllRight && !MembersD.Keys.Contains(current_Member.MemberID))
                                    {
                                        MembersD.Add(current_Member.MemberID,'a');
                                    }
                                    else
                                    {
                                        LoggerType.Error(Path.GetFileName(direction), xml.LineNumber.ToString());
                                        xml.Skip();
                                    }
                                }
                                #endregion
                                #region Project
                                if (xml.Name == "Project")
                                {
                                    current_Project = new Project() {ProjectID=-1 };

                                    if (xml.AttributeCount != Projectattributecount)
                                    {
                                        Projectattributecount = 0;
                                        IsAllRight = false;
                                    }
                                    for (int i = 0; i < Projectattributecount; i++)
                                    {
                                        if (xml.GetAttribute(i) != "")
                                        {
                                            if (i == 0)
                                            {
                                                int x;
                                                IsAllRight = Int32.TryParse(xml.GetAttribute(i), out x);
                                                if (x > 0)
                                                {
                                                    current_Project.ProjectID = x;
                                                }
                                                else
                                                {
                                                    IsAllRight = false;
                                                    xml.Skip();
                                                    break;
                                                }

                                            }
                                            if (i == 1)
                                            {
                                                current_Project.ProjectName = xml.GetAttribute(i);
                                            }
                                            if (i == 2)
                                            {
                                                    DateTime x;
                                                    IsAllRight = DateTime.TryParse(xml.GetAttribute(i), out x);
                                                    current_Project.ProjectCreatedDate = x;
                                                if (x == DateTime.MinValue)
                                                {
                                                    IsAllRight = false;
                                                    xml.Skip();
                                                    break;
                                                }
                                            }
                                            if (i == 3)
                                            {
                                                    DateTime x;
                                                    IsAllRight = DateTime.TryParse(xml.GetAttribute(i), out x);
                                                    current_Project.ProjectDueDate = x;
                                                if (x == DateTime.MinValue)
                                                {
                                                    IsAllRight = false;
                                                    xml.Skip();
                                                    break;
                                                }
                                            }
                                            if (i == 4)
                                            {
                                                current_Project.ProjectDescription = xml.GetAttribute(i);
                                            }
                                        }
                                        else
                                        {
                                            IsAllRight=false;
                                            break;
                                        }
                                    }
                                    if (IsAllRight && current_Project.ProjectID != 0 && !ProjectsD.Keys.Contains(current_Project.ProjectID))
                                    {
                                        ProjectsD.Add(current_Project.ProjectID, 'a');
                                        current_Member.Projects.Add(current_Project);
                                    }
                                    else
                                    {
                                        LoggerType.Error(Path.GetFileName(direction), xml.LineNumber.ToString());
                                        xml.Skip();
                                    }
                                }
                                #endregion
                                break;
                            case XmlNodeType.EndElement:
                                if (xml.Name == "Member")
                                {
                                    if (current_Member != null)
                                    {
                                        current_Team.Members.Add(current_Member);
                                        ProjectsD.Clear();
                                    }
                                }
                                break;
                        }
                        if (!IsAllRight)
                        {
                            TeamsD = null;
                            break;
                        }
                    }
                    if (IsAllRight)
                    {
                        LoggerType.Info(Path.GetFileName(direction), "XML Success");
                        if (AppConfigManager.appSettings.SaveInJson)
                        {
                            StringBuilder sb = new StringBuilder();
                            JsonParser jsParser = new JsonParser();
                            jsParser.FilePath = sb.Append(AppConfigManager.appSettings.JsonFolderPath + jsParser.jsonFoldername(direction)).ToString();
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
                    LoggerType.Info(Path.GetFileName(direction), "All Success" + DateTime.Now.ToLocalTime());
                }
                
            }
           
            catch (IOException e)
            {
                IsAllRight = false;
                LoggerType.Exceptin(Path.GetFileName(direction), e);
            }
            catch (Exception e)
            {
                IsAllRight = false;
                LoggerType.Exceptin(Path.GetFileName(direction), e);
            }
            finally
            {
                if (!IsAllRight)
                {
                    // FolderMonitor.MoveFile(direction, AppConfigManager.Instance.WrongFilePath + Path.GetFileName(direction));
                    File.Move(direction, AppConfigManager.appSettings.WrongFilePath + Path.GetFileName(direction));
                }
                else
                {
                    File.Delete(direction);
                }
            }

                      
        }
        
    }
}
