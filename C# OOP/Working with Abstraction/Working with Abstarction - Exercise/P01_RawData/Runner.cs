using System;
using System.Collections.Generic;

namespace P01_RawData
{
    public static class Runner
    {
        public static void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < lines; i++)
            {
                string model;
                Engine engine;
                Cargo cargo;
                Tire[] tires;

                Input.SplitInput(out model, out engine, out cargo, out tires);
                cars = AddingCar.Add(cars, model, engine, cargo, tires);

            }

            string command = Console.ReadLine();

            PrintCar.PrintTypeOfCar(cars, command);
        }


    }
}
