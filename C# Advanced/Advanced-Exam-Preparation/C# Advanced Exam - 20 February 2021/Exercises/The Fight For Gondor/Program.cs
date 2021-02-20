using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.First
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());


            List<int> plates = Console
                       .ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .ToList();

            Stack<int> wariorOrc = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                wariorOrc = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    int oneMorePlate = int.Parse(Console.ReadLine());
                    plates.Add(oneMorePlate);

                }

                while (wariorOrc.Any() && plates.Any())
                {

                    int orc = wariorOrc.Peek();
                    int plate = plates[0];

                    if (orc == plate)
                    {
                        wariorOrc.Pop();
                        plates.Remove(plate);
                    }
                    else if (orc > plate)
                    {
                        wariorOrc.Push(wariorOrc.Pop() - plate);
                        plates.Remove(plate);
                    }
                    else if (orc < plate)
                    {
                        plates[0] -= orc;
                        wariorOrc.Pop();
                    }
                }
                if (plates.Count == 0)
                {
                    break;
                }
            }
            if (plates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");

                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                Console.WriteLine($"Orcs left: {string.Join(", ", wariorOrc)}");
            }
        }
    }
}
