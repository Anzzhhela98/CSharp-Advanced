using System;
using System.Linq;

namespace _4._Matrix_Shuffling
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
            string[,] matrix = ReadMatrix(data[0], data[1]);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitted = command
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

                if (splitted[0] == "swap")
                {
                    int row1 = int.Parse(splitted[1]);
                    int col1 = int.Parse(splitted[2]);
                    int row2 = int.Parse(splitted[3]);
                    int col2 = int.Parse(splitted[4]);

                    bool indexIsValid = row1 >= 0 && row1 < matrix.GetLength(0) &&
                                    row2 >= 0 && row2 < matrix.GetLength(0) &&
                                    col1 >= 0 && col1 < matrix.GetLength(1) &&
                                    col2 >= 0 && col2 < matrix.GetLength(1);
                    if (indexIsValid)
                    {
                        string curMatrix = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = curMatrix;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowDate = Console
                           .ReadLine()
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
