using System;
using System.Linq;

namespace Jagged_Array_Modification___SecondWay
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowData = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rowData][];

            for (int rows = 0; rows < rowData; rows++)
            {

                int[] data = Console
                           .ReadLine()
                           .Split(" ")
                           .Select(int.Parse)
                           .ToArray();

                jagged[rows] = new int[data.Length];
                for (int col = 0; col < data.Length; col++)
                {
                    jagged[rows][col] = data[col];
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitted = command
                          .Split(" ")
                          .ToArray();

                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);


                switch (splitted[0])
                {
                    case "Add":
                        if (row >= jagged.Length || row < 0 || col >= jagged.Length || col < 0)
                        {
                            Console.WriteLine($"Invalid coordinates");
                            continue;
                        }
                        jagged[row][col] += value;
                        break;

                    case "Subtract":
                        if (row >= jagged.Length || row < 0 || col >= jagged.Length || col < 0)
                        {
                            Console.WriteLine($"Invalid coordinates");
                            continue;
                        }
                        jagged[row][col] -= value;
                        break;
                }
            }
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
