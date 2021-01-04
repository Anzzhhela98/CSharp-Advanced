using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static char[,] matrix;
        static int playerRow;
        static int playerCol;
        static bool IsDead;
        static void Main(string[] args)
        {
            IsDead = false;
            int[] dimensions = Console
                          .ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();
            matrix = new char[dimensions[0], dimensions[1]];
            ReadMatrix();
            string commands = Console.ReadLine();

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'U':
                        Move(-1, 0);
                        break;
                    case 'L':
                        Move(0, -1);
                        break;
                    case 'D':
                        Move(1, 0);
                        break;
                    case 'R':
                        Move(0, 1);
                        break;

                }
                Speread();
                if (IsDead)
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }
            }
        }
        private static void Speread()
        {
            List<int> indexes = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        indexes.Add(row);
                        indexes.Add(col);
                    }
                }
            }

            for (int i = 0; i < indexes.Count; i += 2)
            {
                //Right
                int bunnyRow = indexes[i];
                int bunnyCol = indexes[i + 1];
                if (IsInside(bunnyRow, bunnyCol + 1))
                {
                    if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                    {
                        IsDead = true;
                    }
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
                //Left
                if (IsInside(bunnyRow, bunnyCol - 1))
                {
                    if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                    {
                        IsDead = true;
                    }
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }
                //Down
                if (IsInside(bunnyRow + 1, bunnyCol))
                {
                    if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                    {
                        IsDead = true;
                    }
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }
                //Up
                if (IsInside(bunnyRow - 1, bunnyCol))
                {
                    if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                    {
                        IsDead = true;
                    }
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }
            }
        }

        private static void Move(int row, int col)
        {
            if (!IsInside(playerRow + row, playerCol + col))
            {
                matrix[playerRow, playerCol] = '.';
                Speread();
                PrintMatrix();
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
            }
            if (matrix[playerRow + row, playerCol + col] == 'B')
            {
                Speread();
                PrintMatrix();
                Console.WriteLine($"dead: {playerRow + row} {playerCol + col}");
                Environment.Exit(0);
            }
            matrix[playerRow, playerCol] = '.';
            playerCol += col;
            playerRow += row;

            matrix[playerRow, playerCol] = 'P';
        }
        private static void PrintMatrix()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
        private static char[,] ReadMatrix()
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowDate = Console
                           .ReadLine()
                          .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            return matrix;
        }
    }
}
