using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Model
{
    public class Team
    {
        private List<Player> players;
        private string teamName;
        private int raiting;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string teamName)
          : this()
        {
            this.TeamName = teamName;
        }
        public string TeamName
        {
            get => this.teamName;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (String.Format(Common.Validator.INVALID_NAME, nameof(this.teamName)));
                }
                this.teamName = value;
            }
        }

        public int Raitig =>
            this.players.Count != 0 ? (int)Math.Round(this.players.Sum(s => s.Skills) / this.players.Count) : 0;

        public void Addplayer(Player player) => players.Add(player);

        public void RemovePlayer(string playeName)
        {
            Player player = null;

            foreach (var item in this.players)
            {
                if (item.Name == playeName)
                {
                    player = item;
                }
            }
            if (player == null)
            {
                throw new ArgumentException($"Player {playeName} is not in {this.TeamName} team.");
            }
            this.players.Remove(player);
        }
        public override string ToString()
        {
            return $"{this.TeamName} - {this.Raitig}";
        }
    }
}
