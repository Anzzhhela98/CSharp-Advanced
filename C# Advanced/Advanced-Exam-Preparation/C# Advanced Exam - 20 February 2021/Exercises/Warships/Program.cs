using System;
using System.Linq;

namespace _02.Second
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            string[] cordinates = Console
                          .ReadLine()
                          .Split(",")
                          .ToArray();

            int firsPlayerShips = 0;
            int secondPlayerShips = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console
                                     .ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(char.Parse)
                                     .ToArray();

                FillMatrix(matrix, ref firsPlayerShips, ref secondPlayerShips, row, input);

            }
            ;

            int currFirstShip = firsPlayerShips;
            int curSecondShip = secondPlayerShips;
            ;

            for (int i = 0; i < cordinates.Length; i++)
            {
                int[] splittedCordinates = cordinates[i]
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

                int row = splittedCordinates[0];
                int col = splittedCordinates[1];

                if (!IsInside(matrix, row, col))
                {
                    continue;
                }
                if (matrix[row, col] == '#')
                {
                    matrix[row, col] = 'X';
                    if (IsInside(matrix, row - 1, col))
                    {
                        if (matrix[row - 1, col] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row - 1, col] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row - 1, col] = 'X';
                    }
                    if (IsInside(matrix, row + 1, col))
                    {
                        if (matrix[row + 1, col] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row + 1, col] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row + 1, col] = 'X';
                    }
                    if (IsInside(matrix, row, col - 1))
                    {
                        if (matrix[row, col - 1] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row, col - 1] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row, col - 1] = 'X';
                    }
                    if (IsInside(matrix, row, col + 1))
                    {
                        if (matrix[row, col + 1] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row, col + 1] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row, col + 1] = 'X';
                    }
                    if (IsInside(matrix, row - 1, col + 1))
                    {
                        if (matrix[row - 1, col + 1] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row - 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row - 1, col + 1] = 'X';
                    }
                    if (IsInside(matrix, row - 1, col - 1))
                    {
                        if (matrix[row - 1, col - 1] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row - 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row - 1, col - 1] = 'X';
                    }
                    if (IsInside(matrix, row + 1, col - 1))
                    {
                        if (matrix[row + 1, col - 1] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row + 1, col - 1] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row + 1, col - 1] = 'X';
                    }
                    if (IsInside(matrix, row + 1, col + 1))
                    {
                        if (matrix[row + 1, col + 1] == '<')
                        {
                            firsPlayerShips--;
                        }
                        if (matrix[row + 1, col + 1] == '>')
                        {
                            secondPlayerShips--;
                        }
                        matrix[row + 1, col + 1] = 'X';
                    }
                    continue;
                }

                if (matrix[row, col] == '<')
                {
                    firsPlayerShips--;
                }
                if (matrix[row, col] == '>')
                {
                    secondPlayerShips--;
                }
                matrix[row, col] = 'X';

                if (firsPlayerShips == 0)
                {
                    Console.WriteLine
                        ($"Player Two has won the game! {currFirstShip + curSecondShip - secondPlayerShips} ships have been sunk in the battle.");
                    break;
                }
                if (secondPlayerShips == 0)
                {
                    Console.WriteLine
                      ($"Player One has won the game! {curSecondShip + (currFirstShip - firsPlayerShips)} ships have been sunk in the battle.");
                    break;
                }
            }
            if (secondPlayerShips != 0 && firsPlayerShips != 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firsPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }
        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
        private static void FillMatrix(char[,] matrix, ref int firsPlayerShips, ref int secondPlayerShips, int row, char[] input)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = input[col];

                if (matrix[row, col] == '<')
                {
                    firsPlayerShips++;
                }
                else if (matrix[row, col] == '>')
                {
                    secondPlayerShips++;
                }
            }
        }
    }
}