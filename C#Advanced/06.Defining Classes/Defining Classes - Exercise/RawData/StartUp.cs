using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = Console
                          .ReadLine()
                          .Split(" ",
                           StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

                string model = data[0];

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                Tire[] tires = new Tire[4];

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                int counter = 0;

                for (int tireIndex = 5; tireIndex < data.Length; tireIndex += 2)
                {
                    double currentTirePressure = double.Parse(data[tireIndex]);
                    int currentTireAge = int.Parse(data[tireIndex + 1]);

                    Tire tire = new Tire(currentTirePressure, currentTireAge);
                    tires[counter++] = tire;

                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);

                carList.Add(car);
            }

            string type = Console.ReadLine();

            if (type == "flamable")
            {
                carList
                    .Where(x => x.Engine.EnginePower > 250 && x.Cargo.CargoType == "flamable")
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else if (type == "fragile")
            {
                carList
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires
                    .Any(p => p.TirePressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
