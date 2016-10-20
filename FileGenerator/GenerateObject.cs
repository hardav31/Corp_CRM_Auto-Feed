using FileGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace FileGenerator
{
    class GenerateObject
    {
        Random rand = new Random();
        private List<Project> projects = new List<Project>();
        private List<Member> members = new List<Member>();
        private List<Team> teams = new List<Team>();

        private void GenerateProject()
        {

            int pCount=int.Parse(ConfigurationManager.AppSettings["projectsCount"]);

            for (int i = 0; i < pCount; i++)
            {
                int id = DateTime.Now.Millisecond;
                projects.Add(new Project(id + i, "Project" + i, DateTime.Now, DateTime.Today.AddMonths(1), "Test" + i));
            }
        }
        private void GenerateMember()
        {
            int mCount=int.Parse(ConfigurationManager.AppSettings["membersCount"]);
            
            for (int i = 0; i < mCount; i++)
            {
                int id = DateTime.Now.Millisecond;
                members.Add(new Member(id + i, "Name" + i, "Surname" + i, projects[rand.Next(0, projects.Count)]));
                int r_count = rand.Next(1, 4);
                for (int j = 0; j < r_count;)
                {
                    var pIndex = rand.Next(0, projects.Count);
                    if (!members[i].Projects.Contains(projects[pIndex]))
                    {
                        members[i].Projects.Add(projects[pIndex]);
                        j++;
                    }
                    if (members[i].Projects.Count == projects.Count)
                    {
                        break;
                    }
                }
            }
        }
        private void GenerateTeam()
        {
            int i = 0;
            while (members.Count != 0)
            {
                int mIndex = rand.Next(0, members.Count);
                int id = DateTime.Now.Millisecond;
                teams.Add(new Team(id + i, "Team" + i, members[mIndex]));
                members.RemoveAt(mIndex);
                for (int j = 0; j < 9; j++)
                {
                    if (members.Count == 0) break;
                    var mIndex1 = rand.Next(0, members.Count);
                    teams[i].Members.Add(members[mIndex1]);
                    members.RemoveAt(mIndex1);
                }
                i++;
            }

        }

        public List<Team> GetTeams()
        {

            if (projects.Count != 0)
            {
                projects.Clear();
            }
            GenerateProject();

            if (members.Count != 0)
            {
                members.Clear();
            }
            GenerateMember();

            if (teams.Count != 0)
            {
                teams.Clear();
            }
            GenerateTeam();
            return teams;
        }

    }
}
