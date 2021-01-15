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

            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {

                string[] dataCar = Console
                          .ReadLine()
                          .Split()
                          .ToArray();

                string model = dataCar[0];
                double fuelAmount = double.Parse(dataCar[1]);
                double fuelConsumptionFor1km = double.Parse(dataCar[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] driveCar = command
                        .Split()
                        .ToArray();

                string model = driveCar[1];
                double amountOfKm = double.Parse(driveCar[2]);
                cars.Where(n => n.Model == model)
                    .ToList().ForEach(x => x.Move(amountOfKm));
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
