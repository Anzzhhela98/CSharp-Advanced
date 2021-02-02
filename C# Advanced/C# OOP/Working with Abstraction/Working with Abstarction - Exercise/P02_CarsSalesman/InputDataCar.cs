using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class InputDataCar
    {
        public  static void ReadDataCar(List<Engine> engines)
        {
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                int displacement = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {
                    engines.Add(new Engine(model, power, displacement));
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    engines.Add(new Engine(model, power, efficiency));
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }
        }
    }
}
