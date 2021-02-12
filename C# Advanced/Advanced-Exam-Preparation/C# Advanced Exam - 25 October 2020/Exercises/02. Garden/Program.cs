using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console
                              .ReadLine()
                              .Split()
                              .Select(int.Parse)
                              .ToArray();

            int[,] matrix = new int[data[0], data[1]];
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] flowerPosition = command
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

                int currentRow = flowerPosition[0];
                int currentCol = flowerPosition[0];

                if (Validate(matrix, currentRow, currentCol))
                {
                    for (int row = currentRow; row < currentRow + 1; row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            matrix[row, col] += 1;

                        }
                    }
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = currentCol; col < currentCol+1; col++)
                        {
                            if (row==currentRow&&col==currentCol)
                            {
                                continue;
                            }
                            matrix[row, col] += 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool Validate(int[,] matrix, int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentCol >= 0 && currentCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
