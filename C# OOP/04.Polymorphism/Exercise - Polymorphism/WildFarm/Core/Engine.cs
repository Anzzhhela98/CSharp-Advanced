using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Factories;
using WildFarm.Models.Animal;
using WildFarm.Models.Animal.Contract;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private List<IAnimal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {

            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
                string[] foodArgs = Console
                       .ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                IAnimal animal = ProduceAnimal(animalArgs);

                IFood food = this.foodFactory.ProduceFood(foodArgs[0], int.Parse(foodArgs[1]));

                this.animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            foreach (IAnimal animal1 in this.animals)
            {
                Console.WriteLine(animal1);
            }
        }
        private static IAnimal ProduceAnimal(string[] animalArgs)
        {
            IAnimal animal = null;

            string animlaType = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (animlaType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animlaType == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalArgs[3];

                if (animlaType == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animlaType == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalArgs[4];
                    if (animlaType == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (animlaType == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);

                    }
                }
            }

            return animal;
        }
    }
}
