using Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FileGenerator
{
    class GenerateObject
    {
        Random rand = new Random();
        private static List<Project> projects = new List<Project>();
        private Dictionary<int, Member> members = new Dictionary<int, Member>();
        private List<Team> teams = new List<Team>();

        private void GenerateProject()
        {
            
            int pCount = int.Parse(ConfigurationManager.AppSettings["projectsCount"]);

            for (int i = 0; i < pCount; i++)
            {
                int id = int.Parse(DateTime.Now.ToString("hhmmssfff"));
                projects.Add(new Project(id + i, "Project" + i, DateTime.Today, DateTime.Today.AddMonths(1), "Test" + i));
            }
        }
        private void GenerateMember()
        {
            int mCount = int.Parse(ConfigurationManager.AppSettings["membersCount"]);

            for (int i = 0; i < mCount; i++)
            {
                int id = int.Parse(DateTime.Now.ToString("hhmmssfff"));
                members.Add(i, new Member(id + i, "Name" + id + i, "Surname" + id + i));
                int r_count = rand.Next(1, 5);
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
            int i = 0, mIndex = 0;
            while (members.Count != 0)
            {
                int id = int.Parse(DateTime.Now.ToString("hhmmssfff"));
                teams.Add(new Team(id + i, "Team" + id + i));
                for (int j = 0; j < 10; j++)
                {
                    teams[i].Members.Add(members[mIndex]);
                    members.Remove(mIndex);
                    mIndex++;
                    if (members.Count == 0)
                        break;
                }
                i++;
            }

        }


        public List<Team> GetTeamList()
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

        public static List<Project> GetProjectsList()
        {
            return projects;
        }

    }
}
