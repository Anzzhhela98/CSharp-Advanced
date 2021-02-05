using System;
using System.Collections.Generic;
using System.Linq;
namespace P02_CarsSalesman
{
    public static class InputDataEngine
    {
        public static void ReadDataEengine(List<Car> cars, List<Engine> engines)
        {
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                string engineModel = parameters[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                int weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    cars.Add(new Car(model, engine, color));
                }
                else if (parameters.Length == 4)
                {

                     weight = int.Parse(parameters[2]);
                    string color = parameters[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }
        }
    }
}