using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputName = string.Empty;
            var names = new Queue<string>();
            while ((inputName = Console.ReadLine()) != "End")
            {
                if (inputName == "Paid")
                {
                    while (names.Any())
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                    continue;
                }
                    names.Enqueue(inputName);
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
