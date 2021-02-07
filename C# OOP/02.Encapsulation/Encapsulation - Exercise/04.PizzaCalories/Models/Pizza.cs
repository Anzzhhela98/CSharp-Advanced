using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        public Dough dough;
        public readonly List<Topping> toppings;
        public Pizza(List<Topping> toppings)
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.dough = dough;
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) ||
                    value.Length > Constants.MAX_LENGHT_OF_PIZZA_NAME ||
                    value.Length < Constants.MIN_LENGHT_OF_PIZZA_NAME)
                {
                    throw new ArgumentException(String.Format(Constants.InvalidArgumentLenghtOfPizzaName,
                        Constants.MIN_LENGHT_OF_PIZZA_NAME, Constants.MAX_LENGHT_OF_PIZZA_NAME));
                }
                this.name = value;
            }
        }

        public int CountOfToppings => this.toppings.Count;
        public double TotalCalories
            => this.dough.Calories + this.toppings.Sum(s => s.ToppingCalories);

        public void AddToppings(Topping topping)
        {
            if (this.toppings.Count > Constants.MAX_COUNT_OF_TOPPINGS)
            {
                throw new InvalidOperationException
                       (String.Format(Constants.InvalidOperationForToppingCount, 0, Constants.MAX_COUNT_OF_TOPPINGS));

            }
            toppings.Add(topping);
        }

        //private double CalculateCalories()
        //{
        //    double rezultOfCalories = this.dough.TotalCalories;

        //    foreach (Topping topping in toppings)
        //    {
        //        rezultOfCalories += topping.TotalCalorie;
        //    }
        //    return rezultOfCalories;
        //}
        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
