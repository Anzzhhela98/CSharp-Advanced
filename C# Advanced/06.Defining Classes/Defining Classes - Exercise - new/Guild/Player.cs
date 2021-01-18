using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }

        private string rank;
        private string descriptopn;
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
            Rank = "Trial";
            Description = "n/a";
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string Description
        {
            get { return descriptopn; }
            set { descriptopn = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");
            return sb.ToString().TrimEnd();
        }
    }
}
