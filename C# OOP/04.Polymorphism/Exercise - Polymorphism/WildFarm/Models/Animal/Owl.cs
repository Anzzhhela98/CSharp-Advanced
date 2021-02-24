using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Owl : Bird
    {
        private const double INCREASE_WEIGHT = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => INCREASE_WEIGHT;

        public override ICollection<Type> PrefferedFoods => new List<Type> { typeof(Meat) };

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
