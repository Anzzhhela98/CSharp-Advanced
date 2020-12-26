using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console
                          .ReadLine()
                          .Split(" ",
                           StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
            char[,] matrix = ReadMatrix(data[0], data[1]);
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool isEqual = matrix[row, col] == matrix[row, col + 1] &&
                                    matrix[row + 1, col] == matrix[row + 1, col + 1] &&
                                    matrix[row, col] == matrix[row + 1, col];
                    if (isEqual)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowDate = Console
                           .ReadLine()
                           .Split(" ",
                            StringSplitOptions.RemoveEmptyEntries)
                           .Select(char.Parse)
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
