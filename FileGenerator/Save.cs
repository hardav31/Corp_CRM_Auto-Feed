using FileGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FileGenerator
{
    class Save
    {
        public static string Filepath { get; set; }
        public static void ToXml(List<Team> teams)
        {
            try
            {
                using (FileStream fs = new FileStream(Filepath, FileMode.Create))
                {
                    XmlSerializer s = new XmlSerializer(teams.GetType());
                    s.Serialize(fs, teams);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void ToCsv(List<Team> teams)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(Filepath, FileMode.Create)))
                {
                    string[] headers =
                        {
                        "TeamID", "TeamName",
                        "MemberID","MemberName","MemberSurname",
                        "ProjectID","ProjectName","ProjectCreatedDate","ProjectDueDate","ProjectDescription"
                        };
                    sw.WriteLine(string.Join(",", headers));
                    for (var i = 0; i < teams.Count; i++)
                    {
                        for (var j = 0; j < teams[i].Members.Count; j++)
                        {
                            for (var k = 0; k < teams[i].Members[j].Projects.Count; k++)
                            {

                                List<string> row = new List<string>();
                                row.Add(teams[i].TeamID.ToString());
                                row.Add(teams[i].TeamName);
                                row.Add(teams[i].Members[j].MemberID.ToString());
                                row.Add(teams[i].Members[j].MemberName);
                                row.Add(teams[i].Members[j].MemberSurname);
                                row.Add(teams[i].Members[j].Projects[k].ProjectID.ToString());
                                row.Add(teams[i].Members[j].Projects[k].ProjectName);
                                row.Add(teams[i].Members[j].Projects[k].ProjectCreatedDate.ToString());
                                row.Add(teams[i].Members[j].Projects[k].ProjectDueDate.ToString());
                                row.Add(teams[i].Members[j].Projects[k].ProjectDescription);
                                sw.WriteLine(String.Join(",", row.ToArray()));

                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {

                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
