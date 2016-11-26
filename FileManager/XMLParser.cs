using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Models;
using System.IO;
using App_Configuration;
using Pbar;
using LogManager;


namespace FileManager
{
   public class XMLParser
    {
        private static readonly Lazy<XMLParser> lazy = new Lazy<XMLParser>(() => new XMLParser());
        public static XMLParser xmlParserObj { get { return lazy.Value; } }
        private XMLParser()
        {
        }

        public void XMLFileReader(string direction)
        {
            string fileName = Path.GetFileName(direction);
            bool IsAllRight = true;
            Dictionary<int, Team> TeamsD = new Dictionary<int, Team>();
            HashSet<int> MembersH = new HashSet<int>();// for compare all Member's 
            Dictionary<int, Project> ProjectsD = new Dictionary<int, Project>(); // for compare All Project's 
            try
            {
                Team current_Team = null;
                Member current_Member = null;
                Project current_Project = null;
                int MembersCountDynamic;


                int Teamattributecount = 2;
                int Memberattributecount = 3;
                int Projectattributecount = 5;


                using (XmlTextReader xml = new XmlTextReader(direction))
                {
                    while (xml.Read())
                    {
                        switch (xml.NodeType)
                        {
                            case XmlNodeType.Element:
                                #region Team
                                if (xml.Name == "Team")
                                {
                                    current_Team = new Team();

                                    if (xml.AttributeCount != Teamattributecount)
                                    {
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
                                        LoggerType.WriteToLog(LogType.Error, fileName, xml.LineNumber.ToString());
                                        IsAllRight = false;
                                    }
                                }
                                #endregion
                                #region Member
                                if (xml.Name == "Member")
                                {
                                    current_Member = new Member();
                                    if (xml.AttributeCount != Memberattributecount)
                                    {
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
                                            IsAllRight = false;
                                            break;
                                        }
                                    }
                                    MembersCountDynamic = MembersH.Count;
                                    MembersH.Add(current_Member.MemberID);
                                    if (MembersCountDynamic == MembersH.Count)
                                    {
                                        IsAllRight = false;
                                    }
                                    if (!IsAllRight)
                                    {
                                        LoggerType.WriteToLog(LogType.Error, fileName, xml.LineNumber.ToString());
                                    }
                                }
                                #endregion
                                #region Project5
                                if (xml.Name == "Project")
                                {
                                    current_Project = new Project();
                                    if (xml.AttributeCount != Projectattributecount)
                                    {
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
                                            IsAllRight = false;
                                        }
                                    }
                                    if (IsAllRight && !ProjectsD.Keys.Contains(current_Project.ProjectID))
                                    {
                                          ProjectsD[current_Project.ProjectID] = current_Project;
                                        //ProjectsD[current_Project1.ProjectID].ProjectName = current_Project1.ProjectName;
                                        //ProjectsD[current_Project1.ProjectID].ProjectCreatedDate = current_Project1.ProjectCreatedDate;
                                        //ProjectsD[current_Project1.ProjectID].ProjectDueDate = current_Project1.ProjectDueDate;
                                        //ProjectsD[current_Project1.ProjectID].ProjectDescription = current_Project1.ProjectDescription;
                                       
                                    }
                                    else
                                    {
                                        IsAllRight = false;
                                        LoggerType.WriteToLog(LogType.Error, fileName, xml.LineNumber.ToString());
                                    }
                                }
                                #endregion                            
                                break;

                            case XmlNodeType.Text:
                                #region ProjectID
                                int ID;
                                IsAllRight = Int32.TryParse(xml.Value, out ID);
                                if (ID <= 0)
                                {
                                    IsAllRight = false;
                                }
                                if (IsAllRight && !current_Member.Projects.Exists(p => p.ProjectID == ID))
                                {
                                    if (!ProjectsD.Keys.Contains(ID))
                                    {
                                        IsAllRight = false;
                                        break;
                                    }
                                    current_Member.Projects.Add(ProjectsD[ID]);
                                }
                                else
                                {
                                    IsAllRight = false;
                                    LoggerType.WriteToLog(LogType.Error, fileName, xml.LineNumber.ToString());
                                }
                                #endregion
                                break;

                            case XmlNodeType.EndElement:
                                #region EndMember
                                if (xml.Name == "Member")
                                {
                                    if (IsAllRight)
                                    {
                                        current_Team.Members.Add(current_Member); //adding current_Member in current_Team 
                                    }
                                }
                                #endregion
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

            }

            catch (IOException e)
            {
                IsAllRight = false;
                LoggerType.WriteToLog(fileName, e);
            }
            catch (Exception e)
            {
                IsAllRight = false;
                LoggerType.WriteToLog(fileName, e);
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
