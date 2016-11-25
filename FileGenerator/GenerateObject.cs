using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace FileGenerator
{
    class GenerateObject
    {
        private static readonly Lazy<GenerateObject> lazy = new Lazy<GenerateObject>(() => new GenerateObject());
        public static GenerateObject generateObject { get { return lazy.Value; } }

        Random rand = new Random();
        private List<Project> projects = new List<Project>();
        private Dictionary<int, Member> members = new Dictionary<int, Member>();
        private List<Team> teams = new List<Team>();

        public int pCount { get; set; }
        public int mCount { get; set; }

        private void GenerateProject()
        {
            for (int i = 0; i < pCount; i++)
            {
                int id = int.Parse(DateTime.Now.ToString("hhmmssff"));
                projects.Add(new Project(id + i, "Project" + i, DateTime.Today, DateTime.Today.AddMonths(1), "Test" + i));
            }
        }
        private void GenerateMember()
        {
            int k = 0;
            for (int i = 0; i < mCount; i++)
            {
                int id = int.Parse(DateTime.Now.ToString("hhmmssfff"));
                members.Add(i, new Member(id + i, "Name" + id + i, "Surname" + id + i));

                int r_count = pCount / mCount;
                if (r_count < 1) r_count = 1;

                for (int j = 0; j < r_count + 1;)
                {
                    members[i].Projects.Add(projects[k]);
                    j++;
                    k++;
                    if (k == projects.Count)
                    {
                        k = 0;
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
                int id = int.Parse(DateTime.Now.ToString("hhmmssffff"));
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


        public void Generate()
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
        }

        public List<Project> GetProjectsList()
        {
            return projects;
        }
        public Dictionary<int, Member> GetMembersList()
        {
            return members;
        }
        public List<Team> GetTeamsList()
        {
            return teams;
        }

    }
}
