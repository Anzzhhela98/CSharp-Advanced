namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get; private set; }
        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players." + Environment.NewLine +
                   $"Reserve team has {this.ReserveTeam.Count} players.";
        }
    }
}