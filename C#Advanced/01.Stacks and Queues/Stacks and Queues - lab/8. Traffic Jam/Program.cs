using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int durringCars = int.Parse(Console.ReadLine());
            string input = string.Empty;

            var addCars = new Queue<string>();
            var passesCars = new Queue<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < durringCars; i++)
                    {
                        if (addCars.Count == 0)
                        {
                            continue;
                        }
                        PrintDurringCars(addCars, passesCars);
                    }
                    continue;
                }
                addCars.Enqueue(input);
            }
            Console.WriteLine($"{passesCars.Count} cars passed the crossroads.");

        }

        private static void PrintDurringCars(Queue<string> addCars, Queue<string> passesCars)
        {
            passesCars.Enqueue(addCars.Peek());
            Console.WriteLine($"{addCars.Dequeue()} passed!");
        }
    }
}
