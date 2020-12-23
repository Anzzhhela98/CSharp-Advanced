using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(rowsAndColumns, rowsAndColumns);

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
                        if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
                        {
                            Console.WriteLine($"Invalid coordinates");
                            continue;
                        }
                        matrix[row, col] += value;
                        break;

                    case "Subtract":
                        if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
                        {
                            Console.WriteLine($"Invalid coordinates");
                            continue;
                        }
                        matrix[row, col] -= value;
                        break;
                }
            }
            PrintMatrix(matrix);

        }


        static void PrintMatrix(int[,] matrix)
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
        static int[,] ReadMatrix(int rows, int cols)
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
