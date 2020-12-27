using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console
                           .ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();
            string snake = Console.ReadLine();

            char[,] matrixSnake = new char[dimensions[0], dimensions[1]];
            int count = 0;
            for (int row = 0; row < matrixSnake.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrixSnake.GetLength(1); col++)
                    {
                        matrixSnake[row, col] = snake[count++];
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                    }
                    continue;
                }
                for (int cols = matrixSnake.GetLength(1) - 1; cols >= 0; cols--)
                {
                    matrixSnake[row, cols] = snake[count++];
                    if (count == snake.Length)
                    {
                        count = 0;
                    }
                }
            }

            PrintMatrix(matrixSnake);
        }

        private static void PrintMatrix(char[,] matrixSnake)
        {
            for (int row = 0; row < matrixSnake.GetLength(0); row++)
            {
                for (int col = 0; col < matrixSnake.GetLength(1); col++)
                {
                    Console.Write(matrixSnake[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
