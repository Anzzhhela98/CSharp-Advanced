using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> uniqueCarNumber = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitted = input
                          .Split(", ")
                          .ToArray();
                string direction = splitted[0];
                string carNumber = splitted[1];

                if (direction == "IN")
                {
                    uniqueCarNumber.Add(carNumber);
                }
                else
                {
                    uniqueCarNumber.Remove(carNumber);
                }

            }
            if (uniqueCarNumber.Any())
            {
                foreach (var car in uniqueCarNumber)
                {
                    Console.WriteLine(car);
                }
                return;
            }
            Console.WriteLine("Parking Lot is Empty");
        }
    }
}
