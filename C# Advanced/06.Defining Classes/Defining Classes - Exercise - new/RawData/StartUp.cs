using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Tire[] tires = new Tire[4];

                int counter = 0;
                for (int index = 5; index < data.Length; index += 2)
                {
                    double currentTirePressure = double.Parse(data[index]);
                    int currentTireAge = int.Parse(data[index + 1]);
                    Tire tire = new Tire(currentTirePressure, currentTireAge);
                    tires[counter++] = tire;
                }
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                cars.Where(x => x.Cargo.CargoType == type && x.Tire.Any(p => p.Pressure < 1))
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            else
            {
                cars.Where(x => x.Cargo.CargoType == type && x.Engine.EnginePower > 250)
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }

        }
    }
}
