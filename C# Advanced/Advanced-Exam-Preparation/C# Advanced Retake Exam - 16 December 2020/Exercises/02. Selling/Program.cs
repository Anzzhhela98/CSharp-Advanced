using System;
using System.Collections.Generic;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCol = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rowCol, rowCol];

            int startRow = -1;
            int startCol = -1;

            List<int> pillars = new List<int>();

            InitialiseMatrix(matrix, ref startRow, ref startCol, pillars);

            int collectedMoney = 0;

            bool isMoneyCollected = true;
            while (collectedMoney < 50 && isMoneyCollected) //|
            {
                string command = Console.ReadLine();

                matrix[startRow, startCol] = '-';

                if (command == "right")
                {
                    startCol += 1;

                    if (IsInside(matrix, startRow, startCol))
                    {
                        if (char.IsDigit(matrix[startRow, startCol]))
                        {
                            collectedMoney += (int)char.GetNumericValue(matrix[startRow, startCol]);
                        }
                        else if (matrix[startRow, startCol] == 'O')
                        {
                            matrix[startRow, startCol] = '-';

                            startRow = pillars[2];
                            startCol = pillars[3];

                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isMoneyCollected = false;
                    }
                }
                else if (command == "left")
                {
                    startCol -= 1;
                    if (IsInside(matrix, startRow, startCol))
                    {

                        if (char.IsDigit(matrix[startRow, startCol]))
                        {
                            collectedMoney += (int)char.GetNumericValue(matrix[startRow, startCol]);
                        }
                        else if (matrix[startRow, startCol] == 'O')
                        {
                            matrix[pillars[0], pillars[1]] = '-';

                            startRow = pillars[2];
                            startCol = pillars[3];
                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isMoneyCollected = false;
                    }
                }
                else if (command == "down")
                {
                    startRow += 1;

                    if (IsInside(matrix, startRow, startCol))
                    {

                        if (char.IsDigit(matrix[startRow, startCol]))
                        {
                            collectedMoney += (int)char.GetNumericValue(matrix[startRow, startCol]);
                        }
                        else if (matrix[startRow, startCol] == 'O')
                        {
                            matrix[pillars[0], pillars[1]] = '-';

                            startRow = pillars[2];
                            startCol = pillars[3];
                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isMoneyCollected = false;
                    }
                }
                else if (command == "up")
                {
                    startRow -= 1;
                    if (IsInside(matrix, startRow, startCol))
                    {
                        if (char.IsDigit(matrix[startRow, startCol]))
                        {
                            collectedMoney += (int)char.GetNumericValue(matrix[startRow, startCol]);
                        }
                        else if (matrix[startRow, startCol] == 'O')
                        {
                            matrix[pillars[0], pillars[1]] = '-';

                            startRow = pillars[2];
                            startCol = pillars[3];
                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        isMoneyCollected = false;
                    }
                }
            }
            if (isMoneyCollected)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");

            }
            Console.WriteLine($"Money: {collectedMoney}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);

                }
                Console.WriteLine();
            }
        }

        private static void InitialiseMatrix(char[,] matrix, ref int startRowPosition, ref int startColPosition, List<int> pillars)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    FindPosition(ref startRowPosition, ref startColPosition, pillars, row, input, col);
                }
            }
        }

        private static void FindPosition(ref int startRowPosition, ref int startColPosition, List<int> pillars, int row, string input, int col)
        {
            if (input[col] == 'S')
            {
                startRowPosition = row;
                startColPosition = col;
            }
            else if (input[col] == 'O')
            {
                pillars.Add(row);
                pillars.Add(col);
            }
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
