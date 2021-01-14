using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> listEngine = new List<Engine>();
            List<Car> lisCar = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            string missing = "n/a";

            for (int i = 0; i < n; i++)
            {
                string[] dataEngine = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

                string currentModelEngine = dataEngine[0];
                int power = int.Parse(dataEngine[1]);

                int currDisplacment = 0;
                string currEfficiency = "n/a";

                
                if (dataEngine.Length == 4)
                {
                    currDisplacment = int.Parse(dataEngine[2]);
                    currEfficiency = dataEngine[3];
                }
                else if (dataEngine.Length == 3)
                {
                    if (char.IsLetter(char.Parse(dataEngine[2][0].ToString())))
                    {
                        currEfficiency = dataEngine[2];
                    }
                    else
                    {
                        currDisplacment = int.Parse(dataEngine[2]);
                    }
                }
                Engine engine = new Engine(currentModelEngine, power,
                                            currDisplacment, currEfficiency);
                listEngine.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] dataCar = Console
                         .ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .ToArray();

                string currentModel = dataCar[0];
                string currentModelEngine = dataCar[1];

                int currWeight = 0;
                string currColor = "n/a";

                if (dataCar.Length == 4)
                {
                    currWeight = int.Parse(dataCar[2]);
                    currColor = dataCar[3];
                }
                else if (dataCar.Length == 3)
                {
                    if (char.IsLetter(char.Parse(dataCar[2][0].ToString())))
                    {
                        currColor = dataCar[2];
                    }
                    else
                    {
                        currWeight = int.Parse(dataCar[2]);
                    }
                }

                var engine = listEngine
                    .Where(x => x.ModelEngine == currentModelEngine).FirstOrDefault();

                Car car = new Car(currentModel, engine, currWeight, currColor);

                lisCar.Add(car);

            }
            foreach (Car car in lisCar)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
