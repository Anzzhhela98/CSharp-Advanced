using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] dataEngine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string engineModel = dataEngine[0];
                int power = int.Parse(dataEngine[1]);

                int displacement = 0;
                var efficiency = "n/a";

                if (dataEngine.Length == 4)
                {
                    displacement = int.Parse(dataEngine[2]);
                    efficiency = dataEngine[3];
                }
                else if (dataEngine.Length == 3)
                {
                    if (char.IsLetter(char.Parse(dataEngine[2][0].ToString())))
                    {
                        efficiency = dataEngine[2];
                    }
                    else
                    {
                        displacement = int.Parse(dataEngine[2]);
                    }
                }

                Engine engine = new Engine(engineModel, power, displacement, efficiency);
                engines.Add(engine);
            }

            count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] dataCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string CarModel = dataCar[0];
                string CarEngine = dataCar[1];
                int weight = 0;
                var color = "n/a";

                if (dataCar.Length == 4)
                {
                    weight = int.Parse(dataCar[2]);
                    color = dataCar[3];
                }
                else if (dataCar.Length == 3)
                {
                    if (char.IsLetter(char.Parse(dataCar[2][0].ToString())))
                    {
                        color = dataCar[2];
                    }
                    else
                    {
                        weight = int.Parse(dataCar[2]);
                    }
                }
                var engine = engines.Where(x => x.EngineModel == CarEngine).FirstOrDefault();
                Car car = new Car(CarModel, engine, weight, color);

                cars.Add(car);

            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
