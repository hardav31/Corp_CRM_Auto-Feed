using Models;
using System.Collections.Generic;

namespace FileGenerator
{
    class TeamToSerializableTeam
    {
        static List<SerializableTeam> xTeams = new List<SerializableTeam>();
        static int i = 0;
        public static List<SerializableTeam> Convert(List<Team> teams)
        {
            xTeams.Clear();
            foreach (var team in teams)
            {
                SerializableTeam xt = (new SerializableTeam(team.TeamID, team.TeamName));
                foreach (var member in team.Members)
                {
                    xt.Members.Add(new SerializableMember(member.MemberID, member.MemberName, member.MemberSurname));
                    foreach (var project in member.Projects)
                    {
                        xt.Members[i].ProjectIDs.Add(project.ProjectID);
                    }
                    i++;
                }
                xTeams.Add(xt);
                i = 0;
            }

            return xTeams;
        }
    }
}
