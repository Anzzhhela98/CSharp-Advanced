using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[dimensions][];
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }
            Analyze(jaggedArr);
            ;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitted = command
                          .Split()
                          .ToArray();
                int row = int.Parse(splitted[1]);
                int column = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (!IsInside(jaggedArr, row, column))
                {
                    continue;
                }
                switch (splitted[0])
                {
                    case "Add":
                        jaggedArr[row][column] += value;
                        break;
                    case "Subtract":
                        jaggedArr[row][column] -= value;
                        break;
                }
            }
            PrintJagged(jaggedArr);
        }

        private static void PrintJagged(double[][] jaggedArr)
        {
            foreach (var row in jaggedArr)
            {
                Console.WriteLine($"{string.Join(" ", row)}");
            }
        }

        private static bool IsInside(double[][] jaggedArr, int row, int column)
        {
            return row >= 0 && row < jaggedArr.Length
               && column >= 0 && column < jaggedArr[row].Length;

        }

        private static void Analyze(double[][] jaggedArr)
        {
            for (int rows = 0; rows < jaggedArr.Length - 1; rows++)
            {
                if (jaggedArr[rows].Length == jaggedArr[rows + 1].Length)
                {
                    for (int cols = 0; cols < jaggedArr[rows].Length; cols++)
                    {
                        jaggedArr[rows][cols] *= 2;
                        jaggedArr[rows + 1][cols] *= 2;
                    }
                    continue;
                }
                for (int cols = 0; cols < jaggedArr[rows].Length; cols++)
                {
                    jaggedArr[rows][cols] /= 2;
                }
                for (int cols = 0; cols < jaggedArr[rows + 1].Length; cols++)
                {
                    jaggedArr[rows + 1][cols] /= 2;
                }

            }
        }
    }
}
