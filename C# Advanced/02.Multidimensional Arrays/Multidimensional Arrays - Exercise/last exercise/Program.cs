using System;
using System.Linq;

namespace last_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];
            ReadInput(matrix);

            char[] commands = Console
                           .ReadLine()
                           .ToCharArray();
            int Prow = 0;
            int Pcol = 0;
            FindSartPosition(matrix, ref Prow, ref Pcol);

            bool isDied = false;
            int diedRow = 0;
            int diedCol = 0;

            int wonRow = 0;
            int wondCol = 0;
            int count = commands.Length;
            foreach (var command in commands)
            {
                count--;
                if (command == 'U')
                {
                    if (IsInside(matrix, Prow - 1, Pcol))
                    {
                        if (matrix[Prow - 1, Pcol] == 'B')
                        {
                            isDied = true;

                        }
                        matrix[Prow, Pcol] = '.';
                        matrix[Prow - 1, Pcol] = 'P';
                        Prow--;
                    }
                    SetIndex(Prow, Pcol, out diedRow, out diedCol, out wonRow, out wondCol);

                }
                else if (command == 'L')
                {
                    if (IsInside(matrix, Prow, Pcol - 1))
                    {
                        if (matrix[Prow, Pcol - 1] == 'B')
                        {
                            isDied = true;
                        }
                        matrix[Prow, Pcol] = '.';
                        matrix[Prow, Pcol - 1] = 'P';
                        Pcol--;
                    }
                    diedRow = Prow;
                    diedCol = Pcol;
                    wonRow = Prow;
                    wondCol = Pcol;

                }
                else if (command == 'R')
                {
                    if (IsInside(matrix, Prow, Pcol + 1))
                    {
                        if (matrix[Prow, Pcol + 1] == 'B')
                        {

                            isDied = true;
                        }
                        matrix[Prow, Pcol] = '.';
                        matrix[Prow, Pcol + 1] = 'P';
                        Pcol++;
                    }
                    diedRow = Prow;
                    diedCol = Pcol;
                    wonRow = Prow;
                    wondCol = Pcol;
                }
                else if (command == 'D')
                {
                    if (IsInside(matrix, Prow + 1, Pcol))
                    {
                        if (matrix[Prow + 1, Pcol] == 'B')
                        {

                            isDied = true;
                        }
                        matrix[Prow, Pcol] = '.';
                        matrix[Prow + 1, Pcol] = 'P';
                        Prow++;
                    }
                    diedRow = Prow;
                    diedCol = Pcol;
                    wonRow = Prow;
                    wondCol = Pcol;
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (IsInside(matrix, row - 1, col)&&matrix[row-1,col]!='B')
                            {
                                if (matrix[row - 1, col] == 'P')
                                {
                                    isDied = true;
                                    diedRow = row;
                                    diedCol = col;
                                }
                                matrix[row - 1, col] = 'B';
                            }
                            if (IsInside(matrix, row + 1, col) && matrix[row+1, col] != 'B')
                            {
                                if (matrix[row + 1, col] == 'P')
                                {
                                    isDied = true;
                                    diedRow = row;
                                    diedCol = col;
                                }
                                matrix[row + 1, col] = 'B';
                            }
                            if (IsInside(matrix, row, col - 1) && matrix[row, col - 1] != 'B')
                            {
                                if (matrix[row, col - 1] == 'P')
                                {
                                    isDied = true;
                                    diedRow = row;
                                    diedCol = col;
                                }
                                matrix[row, col - 1] = 'B';
                            }
                            if (IsInside(matrix, row, col + 1)&& matrix[row, col + 1] != 'B')
                            {
                                if (matrix[row, col + 1] == 'P')
                                {
                                    isDied = true;
                                    diedRow = row;
                                    diedCol = col;
                                }
                                matrix[row, col + 1] = 'B';
                            }
                        }
                    }
                }
                if (isDied)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {diedRow} {diedCol}");
                    return;
                }
                if (!isDied && count == 0)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {wonRow} {wondCol}");
                    return;
                }
            }
        }

        private static void SetIndex(int Prow, int Pcol, out int diedRow, out int diedCol, out int wonRow, out int wondCol)
        {
            diedRow = Prow;
            diedCol = Pcol;

            wonRow = Prow;
            wondCol = Pcol;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FindSartPosition(char[,] matrix, ref int Prow, ref int Pcol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        Prow = row;
                        Pcol = col;
                    }
                }
            }
        }

        private static void ReadInput(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console
                          .ReadLine()
                          .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }

    }
}
