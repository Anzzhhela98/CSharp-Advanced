using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimensions, dimensions];
            ReadInput(matrix);
            bool isInside = false;
            string[] coordinates = Console
                         .ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .ToArray();
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] splittedCoordinates = coordinates[i]
                          .Split(",")
                          .Select(int.Parse)
                          .ToArray();
                int rowCoordinate = splittedCoordinates[0];
                int colCoordinate = splittedCoordinates[1];
                for (int row = rowCoordinate; row < matrix.GetLength(0); row++)
                {
                    for (int col = colCoordinate; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[rowCoordinate, colCoordinate] > 0)
                        {
                            isInside = true;
                            int currentNum = matrix[row, col];
                            matrix[row, col] = 0;
                            if (IsInside(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                            {
                                matrix[row - 1, col - 1] -= currentNum;
                            }
                            if (IsInside(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                            {
                                matrix[row - 1, col] -= currentNum;
                            }
                            if (IsInside(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= currentNum;
                            }
                            if (IsInside(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                            {
                                matrix[row, col + 1] -= currentNum;
                            }
                            if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                            {
                                matrix[row, col - 1] -= currentNum;
                            }
                            if (IsInside(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= currentNum;
                            }
                            if (IsInside(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= currentNum;
                            }
                            if (IsInside(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                            {
                                matrix[row + 1, col] -= currentNum;
                            }
                            break;
                        }
                    }
                    if (isInside)
                    {
                        break;

                    }
                }
            }
            Console.WriteLine($"Alive cells: {matrix.Cast<int>().Where(x => x > 0).Count().ToString()}");
            Console.WriteLine($"Sum: {matrix.Cast<int>().Where(x => x > 0).Sum().ToString()}");
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadInput(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
