using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private string toppingTypes;
        private double gram;

        private readonly Dictionary<string, double> DefaultToppingTypes = new Dictionary<string, double>()
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9},
        };

        public Topping(string topingTypes, double gram)
        {
            this.ToppingTypes = topingTypes;
            this.Gram = gram;
        }

        public double Gram
        {
            get => this.gram;
            private set
            {
                if (value < Constants.MIN_WEIGHT_FOR_TOPPING || value > Constants.MAX_WEIGHT_FOR_TOPPING)
                {
                    string currToppingType = this.toppingTypes.First().ToString().ToUpper() + this.toppingTypes.Substring(1);
                    throw new
                        InvalidOperationException(String.Format(Constants.InvalidOperationForGramOfTopping,
                       currToppingType, Constants.MIN_WEIGHT_FOR_TOPPING, Constants.MAX_WEIGHT_FOR_TOPPING));
                }
                this.gram = value;
            }
        }
        public string ToppingTypes
        {
            get => this.toppingTypes;
            private set
            {
                if (!DefaultToppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(String.Format(Constants.InavalidArgumentOfTopping, value));
                }
                this.toppingTypes = value.ToLower();
            }
        }

        public double ToppingCalories
            => DefaultToppingTypes[this.toppingTypes] * this.gram * Constants.MIN_CALORIES_PER_GRAM;

        public double TotalCalorie => this.ToppingCalories;
    }
}
