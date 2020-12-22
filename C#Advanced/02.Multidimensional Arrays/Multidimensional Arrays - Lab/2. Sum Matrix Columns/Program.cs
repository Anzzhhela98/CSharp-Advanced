using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowCow = Console
                          .ReadLine()
                          .Split(", ")
                          .Select(int.Parse)
                          .ToArray();
            int rows = rowCow[0];
            int cows = rowCow[1];

            int sumOfColumns = 0;
            int[,] matrix = new int[rows, cows];
            for (int row = 0; row < rows; row++)
            {
                int[] input = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();
                for (int cow = 0; cow < cows; cow++)
                {
                    matrix[row, cow] = input[cow];
                }
            }
            for (int numCows = 0; numCows < matrix.GetLength(1); numCows++)
            {
                for (int numRows = 0; numRows < matrix.GetLength(0); numRows++)
                {
                    sumOfColumns += matrix[numRows, numCows];
                }
                Console.WriteLine(sumOfColumns);
                sumOfColumns = 0;
            }
        }
    }
}
