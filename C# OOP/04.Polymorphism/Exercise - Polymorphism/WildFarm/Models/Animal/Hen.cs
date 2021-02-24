using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double INCREASE_WEIGHT = 0.35;
        public Hen(string name, double weight,  double wingSize)
            : base(name, weight, wingSize)
        {

        }
        public override double WeightMultiplier => INCREASE_WEIGHT;

        public override ICollection<Type> PrefferedFoods => 
            new List<Type> { typeof(Fruit), typeof(Vegetable),
                             typeof(Meat), typeof(Seeds)};

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
