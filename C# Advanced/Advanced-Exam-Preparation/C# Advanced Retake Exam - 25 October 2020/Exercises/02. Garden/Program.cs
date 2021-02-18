using System;
using System.Linq;
namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console
                      .ReadLine()
                     .Split(" ")
                     .Select(int.Parse)
                     .ToArray();

            int[,] matrix = new int[size[0], size[1]];
            FillMatrix(matrix);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                string[] position = command.Split(" ");
                int row = int.Parse(position[0]);
                int col = int.Parse(position[0]);

                if (!IsPositionValid(matrix, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                matrix[row, col] = -1;

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    matrix[r, col] += 1;
                }
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[row, c] += 1;
                }
            }
            Print(matrix);
        }
        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        public static bool IsPositionValid(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
