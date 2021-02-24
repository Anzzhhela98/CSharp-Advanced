using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double INCREASE_WEIGHT = 0.40;
        public Dog(string name, double weight,  string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier => INCREASE_WEIGHT;

        public override ICollection<Type> PrefferedFoods =>new List<Type> { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
