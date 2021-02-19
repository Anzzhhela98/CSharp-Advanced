using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int enaughFood = 10;
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int startRow = -1;
            int startCol = -1;
            List<int> pillars = new List<int>();

            FillMatrix(matrix, ref startRow, ref startCol, pillars);

            int quantityFood = 0;
            bool isOutside = false;

            while (quantityFood != enaughFood)
            {
                string command = Console.ReadLine();

                matrix[startRow, startCol] = '.';

                startRow = MoveRow(startRow, command);
                startCol = MoveCol(startCol, command);

                if (!IsInside(matrix, startRow, startCol))
                {
                    isOutside = true;
                    break;
                }

                if (matrix[startRow, startCol] == '*')
                {
                    quantityFood++;
                }
                if (matrix[startRow, startCol] == 'B')
                {
                    matrix[startRow, startCol] = '.';

                    if (startRow == pillars[0] && startCol == pillars[1])
                    {
                        startRow = pillars[2];
                        startCol = pillars[3];
                    }
                    else
                    {
                        startRow = pillars[0];
                        startCol = pillars[1];
                    }
                }

                matrix[startRow, startCol] = 'S';
            }
            if (quantityFood == enaughFood)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            if (isOutside)
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {quantityFood}");
            Print(matrix);
        }
        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
        private static int MoveRow(int row, string command)
        {
            if (command == "up")
            {
                row--;
            }
            if (command == "down")
            {
                row++;
            }
            return row;
        }
        private static int MoveCol(int col, string command)
        {
            if (command == "right")
            {
                col++;
            }
            if (command == "left")
            {
                col--;
            }
            return col;
        }
        private static void FillMatrix(char[,] matrix, ref int startRow, ref int startCol, List<int> pillars)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    FindPosition(ref startRow, ref startCol, pillars, row, input, col);
                }
            }
        }
        private static void FindPosition(ref int startRow, ref int startCol, List<int> pillars, int row, string input, int col)
        {
            if (input[col] == 'S')
            {
                startRow = row;
                startCol = col;
            }
            else if (input[col] == 'B')
            {
                pillars.Add(row);
                pillars.Add(col);
            }
        }
    }
}
