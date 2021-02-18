using System;
using System.Collections.Generic;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            const int neededMoney = 50;

            int rowCol = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rowCol, rowCol];

            int startRow = -1;
            int startCol = -1;

            List<int> pillars = new List<int>();
            FillMatrix(matrix, ref startRow, ref startCol, pillars);

            bool isOutside = false;
            int currentMoney = 0;

            while (!isOutside && currentMoney < neededMoney)
            {
                string command = Console.ReadLine();
                matrix[startRow, startCol] = '-';

                startRow = MoveRow(startRow, command);
                startCol = MoveCol(startCol, command);
                if (!IsInside(matrix, startRow, startCol))
                {
                    isOutside = true;
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (matrix[startRow, startCol] == 'O')
                {
                    matrix[startRow, startCol] = '-';
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
                if (char.IsDigit(matrix[startRow, startCol]))
                {
                    currentMoney += (int)char.GetNumericValue(matrix[startRow, startCol]);
                }
                matrix[startRow, startCol] = 'S';
            }
            if (!isOutside)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {currentMoney}");
            Print(matrix);
        }
        public static int MoveRow(int row, string command)
        {
            if (command == "up")
            {
                return row - 1;
            }
            if (command == "down")
            {
                return row + 1;
            }

            return row;
        }
        public static int MoveCol(int col, string command)
        {
            if (command == "left")
            {
                return col - 1;
            }
            if (command == "right")
            {
                return col + 1;
            }

            return col;
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
        private static void FillMatrix(char[,] matrix, ref int startRow, ref int startCol, List<int> pillars)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    FindStartPosition(ref startRow, ref startCol, pillars, row, input, col);
                }
            }
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
        private static void FindStartPosition(ref int startRow, ref int startCol, List<int> pillars, int row, string input, int col)
        {
            if (input[col] == 'S')
            {
                startRow = row;
                startCol = col;
            }
            else if (input[col] == 'O')
            {
                pillars.Add(row);
                pillars.Add(col);
            }
        }
    }
}
