using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console
                          .ReadLine()
                          .Split(" ")
                          .ToArray();

            char[,] matrix = new char[size, size];
            ReadInput(matrix);

            int Srow = 0;
            int Scol = 0;
            FindStart(matrix, ref Srow, ref Scol);

            bool IsInRange = false;

            int valueOfCoals = matrix.Cast<char>().Where(x => x == 'c').Count();

            int currentValueOfCoals = 0;
            int rowIndex = 0;
            int colIndex = 0;

            char letter = ' ';
            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (IsInside(matrix, Srow - 1, Scol))
                        {
                            IsInRange = true;
                            letter = matrix[Srow - 1, Scol];
                            rowIndex = Srow - 1;
                            colIndex = Scol;
                            Srow -= 1;

                        }
                        break;
                    case "down":
                        if (IsInside(matrix, Srow + 1, Scol))
                        {
                            IsInRange = true;
                            letter = matrix[Srow + 1, Scol];
                            rowIndex = Srow + 1;
                            colIndex = Scol;
                            Srow += 1;
                        }
                        break;
                    case "right":
                        if (IsInside(matrix, Srow, Scol + 1))
                        {
                            IsInRange = true;
                            letter = matrix[Srow, Scol + 1];
                            rowIndex = Srow;
                            colIndex = Scol + 1;
                            Scol += 1;
                        }
                        break;
                    case "left":
                        if (IsInside(matrix, Srow, Scol - 1))
                        {
                            IsInRange = true;
                            letter = matrix[Srow, Scol - 1];
                            rowIndex = Srow;
                            colIndex = Scol - 1;
                            Scol -= 1;
                        }
                        break;
                }
                if (IsInRange)
                {
                    if (letter == 'c')
                    {
                        currentValueOfCoals++;
                        matrix[rowIndex, colIndex] = '*';
                        if (valueOfCoals == currentValueOfCoals)
                        {
                            Console.WriteLine($"You collected all coals!" +
                                $" ({rowIndex}, {colIndex})");
                            return;
                        }
                        continue;
                    }
                    if (letter == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{valueOfCoals - currentValueOfCoals} coals left. ({rowIndex}, {colIndex})");
        }
        private static void FindStart(char[,] matrix, ref int Srow, ref int Scol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        Srow = row;
                        Scol = col;
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
                          .Split(" ")
                          .Select(char.Parse)
                          .ToArray();
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
