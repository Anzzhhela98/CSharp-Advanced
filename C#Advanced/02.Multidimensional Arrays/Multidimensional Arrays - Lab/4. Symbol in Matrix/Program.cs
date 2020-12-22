using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowAndColSize = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(rowAndColSize, rowAndColSize);

            static char[,] ReadMatrix(int rows, int cols)
            {
                char[,] matrix = new char[rows, cols];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    string characters = Console.ReadLine();

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = characters[col];
                    }
                }
                return matrix;
            }
            int rowOfsymbol = 0;
            int colOfsymbol = 0;
            bool isFound = false;
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        rowOfsymbol = row;
                        colOfsymbol = col;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    Console.WriteLine($"({rowOfsymbol}, {colOfsymbol})");
                    return;
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
