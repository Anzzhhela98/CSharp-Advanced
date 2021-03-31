using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private List<IFish> fishCollection;
        private List<IDecoration> decorations;
        private string name;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.fishCollection = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fishCollection.AsReadOnly();

        public void AddDecoration(IDecoration decoration) => this.decorations.Add(decoration);
        public bool RemoveFish(IFish fish) => fishCollection.Remove(fish);

        public void AddFish(IFish fish) //?
        {
            if (this.Capacity > 0)
            {
                this.fishCollection.Add(fish);
                this.Capacity--;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var fish in this.fishCollection)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.name} ({this.GetType().Name}):");

            if (this.fishCollection == null)
            {
                sb.AppendLine("none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fishCollection.Select(f => f.Name))}");
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");
            return sb.ToString().TrimEnd();
        }

    }
}
