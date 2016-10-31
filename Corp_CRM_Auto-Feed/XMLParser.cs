using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Specialized;
using FileGenerator.Models;

namespace PraemiumProject
{
    class XMLParser
    {
       //In Progress
        public void XMLFileReader(string direction)
        {
            //TODO: if (file.Length > 1000000)
            Dictionary<int, Team> TeamD = new Dictionary<int, Team>();
            Dictionary<int, string> DicMember = new Dictionary<int,string>(); // for compare all Member's id
            Dictionary<int, string> DicProject = new Dictionary<int,string>(); // for compare Project's id in one Member

            Team current_Team = null;
            Member current_Member = null;
            Project current_Project = null;
            
            int Teamattributecount = 2;
            int Memberattributecount = 3;
            int Projectattributecount = 5;

            using (XmlTextReader xml = new XmlTextReader(direction))
            {
                Console.WriteLine("XmlOpen " + DateTime.Now);
                while (xml.Read())
                {
                    switch (xml.NodeType)
                    {
                        case XmlNodeType.Element:
                            #region Team
                            if (xml.Name == "Team")
                            {
                                current_Team = new Team() { TeamID = -1 };

                                if (xml.AttributeCount != 2)
                                {
                                    Teamattributecount = 0;
                                }
                                for (int i = 0; i < Teamattributecount; i++)
                                {
                                    if (xml.GetAttribute(i) != "")
                                    {
                                        if (i == 0)
                                        {
                                            try
                                            {
                                                current_Team.TeamID = Int32.Parse(xml.GetAttribute(i));
                                            }
                                            catch (FormatException e)
                                            {
                                                //loging : ID isn't correct
                                                current_Team = null;
                                                break;
                                            }
                                        }
                                        if (i == 1)
                                        {
                                            current_Team.TeamName = xml.GetAttribute(i);
                                        }

                                    }
                                    else
                                    {
                                        //logging: Attribute doesn't have value
                                        current_Team = null;
                                        break;
                                    }
                                }
                                if (current_Team != null && current_Team.TeamID != -1 && !TeamD.Keys.Contains(current_Team.TeamID))
                                {
                                    TeamD[current_Team.TeamID] = current_Team;
                                }
                                else
                                {
                                    xml.Skip();
                                    current_Team = null;
                                }
                                Teamattributecount = 2;
                            }
                            #endregion
                            #region Member
                            if (xml.Name == "Member")
                            {
                                current_Member = new Member() { MemberID = -1 };
                                if (xml.AttributeCount != 3)
                                {
                                    Memberattributecount = 0;
                                }

                                for (int i = 0; i < Memberattributecount; i++)
                                {
                                    if (xml.GetAttribute(i) != "")
                                    {
                                        if (i == 0)
                                        {
                                            try
                                            {
                                                current_Member.MemberID = Int32.Parse(xml.GetAttribute(i));
                                            }
                                            catch (FormatException e)
                                            {
                                                current_Member = null;
                                                break;
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
                                        current_Member = null;
                                        break;
                                    }
                                }
                                if (current_Member != null && current_Member.MemberID != -1 && !DicMember.Keys.Contains(current_Member.MemberID))
                                {
                                    DicMember.Add(current_Member.MemberID, "eakan chi");
                                }
                                else
                                {
                                    current_Member = null;
                                    xml.Skip();
                                }
                                Memberattributecount = 3;
                            }
                            #endregion
                            #region Project
                            if (xml.Name == "Project")
                            {
                                current_Project = new Project() { ProjectID = -1 };

                                if (xml.AttributeCount != 5)
                                {
                                    Projectattributecount = 0;
                                }
                                for (int i = 0; i < Projectattributecount; i++)
                                {
                                    if (xml.GetAttribute(i) != "")
                                    {
                                        if (i == 0)
                                        {
                                            try
                                            {
                                                current_Project.ProjectID = Int32.Parse(xml.GetAttribute(i));
                                            }
                                            catch (FormatException e)
                                            {
                                                //loging
                                                current_Member = null;
                                                break;
                                            }
                                        }
                                        if (i == 1)
                                        {
                                            current_Project.ProjectName = xml.GetAttribute(i);
                                        }
                                        if (i == 2)
                                        {
                                            try
                                            {
                                                current_Project.ProjectCreatedDate = DateTime.Parse(xml.GetAttribute(i));
                                            }
                                            catch (FormatException e)
                                            {
                                                current_Project = null;
                                                break;
                                            }
                                        }
                                        if (i == 3)
                                        {
                                            try
                                            {
                                                current_Project.ProjectDueDate = DateTime.Parse(xml.GetAttribute(i));
                                            }
                                            catch (FormatException e)
                                            {
                                                current_Project = null;
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
                                        current_Project = null;
                                        break;
                                    }
                                }
                                if (current_Project != null && current_Project.ProjectID != -1 && !DicProject.Keys.Contains(current_Project.ProjectID))
                                {
                                    DicProject.Add(current_Project.ProjectID, "a");
                                    current_Member.Projects.Add(current_Project);
                                }
                                else
                                {
                                    current_Project = null;
                                }
                                Projectattributecount = 5;
                            }
                            #endregion
                            break;
                        case XmlNodeType.EndElement:
                            if (xml.Name == "Member")
                            {
                                if (current_Member != null)
                                {
                                    current_Team.Members.Add(current_Member);
                                    DicProject.Clear();
                                }
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("XmlClose " + DateTime.Now);
            //foreach (var x in TeamD.Values)
            //{
            //    Console.WriteLine(x.TeamID + " " + x.TeamName);
            //    foreach (var y in x.Members)
            //    {
            //        Console.WriteLine("   " + y.MemberID + " " + y.MemberName + " " + y.MemberSurname);
            //        foreach (var z in y.Projects)
            //        {
            //            Console.WriteLine("      " + z.ProjectID + " " + z.ProjectName + " " + z.ProjectCreatedDate.ToString() + " " + z.ProjectDueDate.ToString() + " " + z.ProjectDescription);
            //        }
            //    }
            //}

        }
        //TODO: Invoke Json or Saving Data in DB methods
    }
}
