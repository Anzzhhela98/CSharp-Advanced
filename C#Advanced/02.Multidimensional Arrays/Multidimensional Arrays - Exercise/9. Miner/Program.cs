using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static int Scol;
        static int Srow;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console
                          .ReadLine()
                          .Split(" ")
                          .ToArray();

            char[,] matrix = new char[size, size];
            ReadInput(matrix);

            bool IsInRange = false;
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
                        matrix[rowIndex, colIndex] = '*';
                    }
                    if (letter == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
            }
            int countCoalsLeft = matrix.Cast<char>().Count(symbol => symbol == 'c');
            Console.WriteLine(countCoalsLeft == 0
                ? $"You collected all coals! ({rowIndex}, {colIndex})"
                : $"{countCoalsLeft} coals left. ({rowIndex}, {colIndex})");
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
                    if (matrix[row, col] == 's')
                    {
                        Srow = row;
                        Scol = col;

                    }
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
