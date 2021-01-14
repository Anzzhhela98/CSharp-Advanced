using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            this.Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }
        public List<Pokemon> Pokemon { get; set; }
        public int Badges { get; set; }
    }
}


