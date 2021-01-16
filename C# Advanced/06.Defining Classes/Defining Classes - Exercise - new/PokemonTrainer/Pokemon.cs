using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string pokemonName, string element, int health)
        {
            PokemonName = pokemonName;
            Element = element;
            Health = health;
        }

        public string PokemonName { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
        public void RemoveHealt()
        {
            this.Health -= 10;
        }

    }
}
