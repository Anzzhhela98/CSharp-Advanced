using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> repositoryOfRabbits;
        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.repositoryOfRabbits = new List<Rabbit>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.repositoryOfRabbits.Count;
        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > this.repositoryOfRabbits.Count)
            {
                repositoryOfRabbits.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = repositoryOfRabbits.FirstOrDefault(x => x.Name == name);

            if (rabbit != null)
            {
                return true;
            }

            return false;
        }
        public void RemoveSpecies(string species)
        {

            repositoryOfRabbits.RemoveAll(x => x.Species == species);
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = repositoryOfRabbits.First(x => x.Name == name);
            rabbit.Available = false;
            return rabbit;

        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> rabbits = new List<Rabbit>();

            foreach (var rabbit in repositoryOfRabbits)
            {
                if (rabbit.Species == species && rabbit.Available == true)
                {
                    rabbits.Add(rabbit);
                    rabbit.Available = false;
                }
            }
            return rabbits.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");

            foreach (var rabbit in repositoryOfRabbits.Where(x => x.Available == true))
            {
                sb.AppendLine($"{rabbit.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
