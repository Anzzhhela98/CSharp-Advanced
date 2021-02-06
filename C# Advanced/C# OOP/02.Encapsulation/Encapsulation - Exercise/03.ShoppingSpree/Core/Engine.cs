using _03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;
        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            ParsePeopleInput();

            ParseProductInput();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ").ToArray();
                string personName = input[0];
                string productName = input[1];

                try
                {
                    Person person = this.people.First(p => p.Name == personName);
                    Product product = this.products.First(p => p.Name == productName);

                    person.BuyProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (Person person1 in people)
            {
                Console.WriteLine(person1.ToString());
            }
        }

        private void ParseProductInput()
        {
            string[] productToBuy = Console
                            .ReadLine()
                            .Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            for (int i = 0; i < productToBuy.Length; i++)
            {
                string[] splittedArgs = productToBuy[i]
                         .Split('=', StringSplitOptions.None)
                         .ToArray();

                string name = splittedArgs[0];
                decimal cost = decimal.Parse(splittedArgs[1]);

                products.Add(new Product(name, cost));
            }
        }

        private void ParsePeopleInput()
        {
            string[] cmdArgs = Console
                          .ReadLine()
                          .Split(';', StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

            for (int i = 0; i < cmdArgs.Length; i++)
            {
                string[] splittedArgs = cmdArgs[i]
                          .Split("=", StringSplitOptions.None)
                          .ToArray();

                string name = splittedArgs[0];
                decimal money = decimal.Parse(splittedArgs[1]);

                people.Add(new Person(name, money));
            }
        }
    }
}
