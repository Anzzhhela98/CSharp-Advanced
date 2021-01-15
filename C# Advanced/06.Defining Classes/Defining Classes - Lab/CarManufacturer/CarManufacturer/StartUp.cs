using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] data = command
                          .Split();

                List<Tire> tiresList = new List<Tire>();

                for (int i = 0; i < data.Length; i += 2)
                {
                    int year = int.Parse(data[i]);
                    double pressuere = double.Parse(data[i + 1]);

                    Tire tire = new Tire(year, pressuere);
                    tiresList.Add(tire);
                }

                tires.Add(tiresList.ToArray());
            }

            List<Engine> engines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] data = command
                        .Split();

                int horsePower = int.Parse(data[0]);
                double cubicCapacity = double.Parse(data[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }
            List<Car> carList = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] data = command
                       .Split();

                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);
                double fuelQuantity = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tiresIndex = int.Parse(data[6]);

                Car car = new Car(make, model, year, fuelQuantity,
                    fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                carList.Add(car);
            }

            carList = carList.Where(x => x.Year > 2016
              && x.Engine.HorsePower > 330 && x.Tires.Sum(x => x.Pressure) >= 9
              && x.Tires.Sum(x => x.Pressure) <= 10).ToList();

            foreach (var car in carList)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

        }
    }
}
