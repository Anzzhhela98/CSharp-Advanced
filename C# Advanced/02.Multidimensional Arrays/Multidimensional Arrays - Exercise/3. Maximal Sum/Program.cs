using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
            int[,] matrix = ReadMatrix(data[0], data[1]);

            int maxSum = int.MinValue;
            int currSum = 0;

            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                             matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                             matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        indexCol = col;
                        indexRow = row;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = indexRow; row < indexRow+3; row++)
            {
                for (int col = indexCol; col < indexCol+3; col++)
                {
                    Console.Write(matrix[row, col]+ " ");
                }
                Console.WriteLine();
            }
        }
        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowDate = Console
                           .ReadLine()
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
            return matrix;
        }
    }
}
