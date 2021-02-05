using System;
using System.Collections.Generic;

namespace P02_CarsSalesman
{
     static class Printer
    {
        public static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
