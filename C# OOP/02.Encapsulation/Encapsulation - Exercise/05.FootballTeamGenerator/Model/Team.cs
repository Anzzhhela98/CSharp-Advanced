using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator.Model
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private Team()
        {
            this.players = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (String.Format(Common.Validator.INVALID_NAME, nameof(this.name)));
                }
                this.name = value; 
            }
        }

        private int raiting;

        public int Raitig =>players.
       

    }
}
