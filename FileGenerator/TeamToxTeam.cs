using Models;
using System.Collections.Generic;

namespace FileGenerator
{
    class TeamToxTeam
    {
        static List<xTeam> xTeams = new List<xTeam>();
        static int i = 0;
        public static List<xTeam> Convert(List<Team> teams)
        {
            xTeams.Clear();
            foreach (var team in teams)
            {
                xTeam xt = (new xTeam(team.TeamID, team.TeamName));
                foreach (var member in team.Members)
                {
                    xt.Members.Add(new xMember(member.MemberID, member.MemberName, member.MemberSurname));
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
