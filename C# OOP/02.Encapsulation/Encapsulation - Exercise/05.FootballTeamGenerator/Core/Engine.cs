using _05.FootballTeamGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Team> teams = new List<Team>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] dataPlayer;
                    string currentCommand, teamName, playerName;

                    SplitInput(command, out dataPlayer, out currentCommand, out teamName, out playerName);

                    switch (currentCommand)
                    {
                        case "Team":
                            Team team = MakeTeam(teams, teamName);
                            break;

                        case "Add":
                            Add(teams, dataPlayer, teamName, out playerName, out team);
                            break;

                        case "Remove":
                            Remove(teams, dataPlayer, teamName, out playerName, out team);
                            break;

                        case "Rating":
                            GiveRating(teams, teamName);
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void SplitInput(string command, out string[] dataPlayer, out string currentCommand, out string teamName, out string playerName)
        {
            dataPlayer = command
                      .Split(";")
                      .ToArray();
            currentCommand = dataPlayer[0];
            teamName = dataPlayer[1];
            playerName = string.Empty;
        }

        private static Team MakeTeam(List<Team> teams, string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
            return team;
        }

        private static void GiveRating(List<Team> teams, string teamName)
        {
            if (!teams.Any(n => n.TeamName == teamName))
            {
                throw new ArgumentException(String.Format(Common.Validator.INVALID_TEAM_NAME, teamName));
            }

            foreach (var item in teams)
            {
                if (item.TeamName == teamName)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void Remove(List<Team> teams, string[] dataPlayer, string teamName, out string playerName, out Team team)
        {
            playerName = dataPlayer[2];

            team = teams.FirstOrDefault(x => x.TeamName == teamName);

            team.RemovePlayer(playerName);
        }

        private static void Add(List<Team> teams, string[] dataPlayer, string teamName, out string playerName, out Team team)
        {
            playerName = dataPlayer[2];
            if (!teams.Any(n => n.TeamName == teamName))
            {
                throw new ArgumentException
                    (String.Format(Common.Validator.INVALID_TEAM_NAME, teamName));
            }

            int endurance = int.Parse(dataPlayer[3]);
            int sprint = int.Parse(dataPlayer[4]);
            int dribble = int.Parse(dataPlayer[5]);
            int passing = int.Parse(dataPlayer[6]);
            int shooting = int.Parse(dataPlayer[7]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            Player player = new Player(playerName, stats);

            team = teams.FirstOrDefault(x => x.TeamName == teamName);

            team.Addplayer(player);
        }
    }
}
