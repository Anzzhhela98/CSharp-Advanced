using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private const decimal MINIMUM_PRICE = 1;
        private string species;
        private decimal price;
        private string name;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }

        public string Species
        {
            get { return this.species; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }
                this.species = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < MINIMUM_PRICE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                this.price = value;
            }
        }

        public  int Size { get; protected set; }

        public abstract void Eat();
    }
}
