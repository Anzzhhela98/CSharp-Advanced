using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        public Guild(string nameGuild, int capacity)
        {
            this.Name = nameGuild;
            this.Capacity = capacity;
            this.players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.players.Count;
        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.players.Count)
            {
                players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (players.Contains(player))
            {
                players.Remove(player);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name && x.Rank != "Member");

            if (player != null)
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name && x.Rank != "Trial");

            if (player != null)
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> removedPlayers = new List<Player>();

            foreach (var player in players)
            {
                if (player.Class == @class)
                {
                    removedPlayers.Add(player);
                }
            }

            this.players = players.Where(p => p.Class != @class).ToList();

            return removedPlayers.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
