using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Aquariums.Models;
using AquaShop.Models.Decorations.Models;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Models;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepo;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepo = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Plant")
            {
                decorationRepo.Add(new Plant());
            }
            else if (decorationType == "Ornament")
            {
                decorationRepo.Add(new Ornament());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            StringBuilder sb = new StringBuilder();

            Fish fish = null;

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

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fish.GetType().Name == "FreshwaterFish")
            {
                aquarium.AddFish(fish);
                sb.AppendLine(String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName));
            }
            else if (aquarium.GetType().Name == "SaltwaterAquarium" && fish.GetType().Name == "SaltwaterFish")
            {
                aquarium.AddFish(fish);
                sb.AppendLine(String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName));
            }
            else
            {
                sb.AppendLine(OutputMessages.UnsuitableWater);
            }

            return sb.ToString().TrimEnd();
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decorationSum = aquarium.Decorations.Sum(x => x.Price);
            var fishSum = aquarium.Fish.Sum(x => x.Price);

            var totalSum = decorationSum + fishSum;
            return string.Format(OutputMessages.AquariumValue, aquariumName, totalSum);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = decorationRepo.Models.FirstOrDefault(d => d.GetType().Name == decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorationRepo.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo());
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
