

using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }
        public List<Pokemon> Pokemon { get; set; }

        public void Give()
        {
            this.Badges++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Badges} {this.Pokemon.Count}");
            return sb.ToString().TrimEnd();
        }
    }
}
