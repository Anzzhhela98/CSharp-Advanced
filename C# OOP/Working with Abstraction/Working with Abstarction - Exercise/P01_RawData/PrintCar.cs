using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
   public  static  class PrintCar
    {
        public static void PrintTypeOfCar(List<Car> cars, string command)
        {
            if (command == "fragile")
            {
                cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
            }
            else
            {
                cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
