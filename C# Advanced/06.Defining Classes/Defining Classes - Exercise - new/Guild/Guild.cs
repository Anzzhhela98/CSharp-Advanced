using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string nameGuild, int capacity)
        {
            NameGuild = nameGuild;
            Capacity = capacity;
            roster = new List<Player>();
        }

        private List<Player> roster;


        public string NameGuild { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string namey)
        {
            if (roster.Any(x => x.Name == namey))
            {
                roster.RemoveAll(x => x.Name == namey);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {

            if (roster.Any(x => x.Name == name && x.Rank != "Member"))
            {
                roster.Find(x => x.Name == name).Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name && x.Rank != "Trial"))
            {
                roster.Find(x => x.Name == name).Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] arr = roster.Where(x => x.Class == clas).ToArray();
            roster = roster.Where(x => x.Class != clas).ToList();

            return arr;
        }
        public int Count => this.roster.Count;

        public string Report()
        {

            StringBuilder rezult = new StringBuilder();

            rezult.AppendLine($"Players in the guild: {this.NameGuild}");
            foreach (var player in roster)
            {
                rezult.AppendLine($"Player {player.Name}: {player.Class}");
                rezult.AppendLine($"Rank: {player.Rank}");
                rezult.AppendLine($"Description: {player.Description}");
            }
            return rezult.ToString().TrimEnd();
        }
    }
}
