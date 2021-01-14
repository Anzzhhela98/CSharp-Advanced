using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeSqueareMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(sizeSqueareMatrix, sizeSqueareMatrix);
            int sum = 0;
            int tempCOls = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < 1; cols++)
                {
                    sum += matrix[rows, tempCOls];
                    tempCOls++;

                }
            }
            Console.WriteLine(sum);

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
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
            }
        }
    }
}
