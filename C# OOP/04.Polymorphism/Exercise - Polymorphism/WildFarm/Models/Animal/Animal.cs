using System;
using System.Collections.Generic;
using WildFarm.Models.Animal.Contract;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        private const string DEF_EXC_MSG = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> PrefferedFoods { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException
                    (String.Format(DEF_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{ this.Name},";
        }
    }
}
