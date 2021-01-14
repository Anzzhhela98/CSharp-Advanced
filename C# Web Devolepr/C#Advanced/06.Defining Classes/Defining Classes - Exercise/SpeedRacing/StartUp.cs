using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> uniqueModel = new List<Car>();
            for (int i = 0; i < count; i++)
            {
                // "{model} {fuelAmount} {fuelConsumptionFor1km}" 
                string[] info = Console.ReadLine().Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);

                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionFor1km = double.Parse(info[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                uniqueModel.Add(car);

            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);

                string model = info[1];
                double distance = double.Parse(info[2]);

                Car car = uniqueModel
                         .FirstOrDefault(x => x.Model == model);

                car.Drive(distance);
            }

            foreach (var car in uniqueModel)
            {
                Console.WriteLine(car);
            }

        }
    }
}
