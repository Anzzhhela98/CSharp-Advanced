using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowndCol = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(rowndCol, rowndCol);

            int tempCol = 0;
            int tempRowLeft = matrix.GetLength(0) - 1;

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    primaryDiagonal += matrix[row, tempCol];
                    tempCol++;

                    secondaryDiagonal += matrix[row, tempRowLeft];
                    tempRowLeft--;
                }
            }
            Console.WriteLine($"{Math.Abs(secondaryDiagonal - primaryDiagonal)}");
        }
        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowDate = Console
                           .ReadLine()
                           .Split(" ")
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
