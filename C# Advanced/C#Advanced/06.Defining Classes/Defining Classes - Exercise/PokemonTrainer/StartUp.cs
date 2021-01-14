using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers =
                new Dictionary<string, Trainer>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] data = Console
                          .ReadLine()
                          .Split()
                          .ToArray();

                string trainerName = data[0];

                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                Trainer trainer = trainers[trainerName];

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.Pokemon.Add(pokemon);
            }
        }
    }
}
