using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        private const double INCREASE_WEIGHT = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiplier => INCREASE_WEIGHT;

        public override ICollection<Type> PrefferedFoods =>
                        new List<Type> { typeof(Meat), typeof(Vegetable) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
