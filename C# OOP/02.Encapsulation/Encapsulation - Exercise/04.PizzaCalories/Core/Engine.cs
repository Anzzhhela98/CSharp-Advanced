using _04.PizzaCalories.Models;
using System;
using System.Linq;

namespace _04.PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            string[] pizzaData = Console
                              .ReadLine()
                              .Split(" ")
                              .ToArray();

            string[] doughData = Console
                          .ReadLine()
                          .Split(" ")
                          .ToArray();

            Dough dough = MadeDough(doughData);
            Pizza pizza = new Pizza(pizzaData[1],dough);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingData = input.Split().ToArray();
                Topping topping = CreateTopping(toppingData);
                pizza.AddToppings(topping);
            }
            Console.WriteLine(pizza);

        }

        private Dough  MadeDough(string[] doughData)
        {
            string typeOfDough = doughData[1];
            string technique = doughData[2];
            double weight = double.Parse(doughData[3]);

            Dough dough = new Dough(typeOfDough, technique, weight);
            return dough;
        }
        private Topping CreateTopping(string[] toppingInfo)
        {
            string type = toppingInfo[1];
            double weight = double.Parse(toppingInfo[2]);
            Topping topping = new Topping(type, weight);
            return topping;
        }
    }
}
