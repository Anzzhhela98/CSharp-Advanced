using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] data = command
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);


                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);

                trainers[trainerName].Pokemon.Add(pokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string currElement = command;

                trainers.Where(x => x.Value.Pokemon.Any(x => x.Element == currElement))
                        .Select(b => b.Value.Badges + 1).ToList();

                foreach (Trainer trainer in trainers.Values)
                {
                    if (trainer.Pokemon.Any(x => x.Element == currElement))
                    {
                        trainer.Give();
                    }
                    else
                    {
                        trainer.Pokemon.ForEach(h => h.RemoveHealt());

                        List<Pokemon> deadPokemons = trainer.Pokemon
                            .Where(x => x.Health <= 0)
                            .ToList();

                        foreach (Pokemon deadPokemon in deadPokemons)
                        {
                            trainer.Pokemon.Remove(deadPokemon);
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.Values.OrderByDescending(p => p.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
