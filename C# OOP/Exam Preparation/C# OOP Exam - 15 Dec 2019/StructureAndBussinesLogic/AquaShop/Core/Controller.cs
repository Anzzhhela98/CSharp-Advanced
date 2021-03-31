using System;
using AquaShop.Core.Contracts;
using AquaShop.Repositories;
using System.Collections.Generic;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Decorations;
using System.Linq;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorationRepository.Add(decoration);

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            IFish fish = null;

            if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if ((fishType == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium") ||
                (fishType == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium"))
            {
                aquarium.AddFish(fish);
                return String.Format(OutputMessages.EntityAddedToAquarium, fishType, fishName);
            }

            return "Water not suitable.";
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var valueOfFish = aquarium.Fish.Sum(x => x.Price);
            var valueOfDecoration = aquarium.Decorations.Sum(x => x.Price);
            var result = valueOfFish + valueOfDecoration;

            return $"The value of Aquarium {aquariumName} is {result}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            int count = 0;
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
                count++;
            }

            return String.Format(OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decoration = decorationRepository.Models.FirstOrDefault(d => d.GetType().Name == decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
