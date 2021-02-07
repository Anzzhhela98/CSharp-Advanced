using System.Collections.Generic;
using System;
using _04.PizzaCalories.Common;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double gram;

        public readonly Dictionary<string, double> DefaultFlour = new Dictionary<string, double>
       {
           { "white", 1.5},
           { "wholegrain", 1.0}
       };
        public readonly Dictionary<string, double> DefaultBaking = new Dictionary<string, double>
       {
           { "crispy", 0.9},
           { "chewy", 1.1},
           { "homemade", 1.0}
       };
        public Dough(string flourType, string bakingTechnique,
            double gram)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Gram = gram;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!DefaultFlour.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(Constants.InavalidArgumentOfDough);
                }
                this.flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!DefaultBaking.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(Constants.InavalidArgumentOfDough);
                }
                this.bakingTechnique = value.ToLower();
            }
        }
        public double Gram
        {
            get => this.gram;
            private set
            {
                if (value < Constants.MIN_WEIGHT_FOR_DOUGH || value > Constants.MAX_WEIGHT_FOR_DOUGH)
                {
                    throw new
                        InvalidOperationException(String.Format(Constants.InvalidOperationForGramOfDough,
                        Constants.MIN_WEIGHT_FOR_DOUGH, Constants.MAX_WEIGHT_FOR_DOUGH));
                }
                this.gram = value;
            }
        }
        
        public double Calories
            => (Constants.MIN_CALORIES_PER_GRAM * this.gram) * this.DefaultFlour[this.flourType] * this.DefaultBaking[this.bakingTechnique];
        public double TotalCalories => this.Calories;
    }
}
