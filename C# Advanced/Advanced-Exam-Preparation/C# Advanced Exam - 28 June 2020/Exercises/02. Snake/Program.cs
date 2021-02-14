using System;
using System.Collections.Generic;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NEED_FOOD = 10;
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int startRow = 0;
            int startCol = 0;
            List<int> burrowsPosition = new List<int>();

            InitialiseMatrix(matrix, ref startRow, ref startCol, burrowsPosition);
            int quantutyFood = 0;

            bool isOutside = false;
            while (quantutyFood < NEED_FOOD && !isOutside)
            {
                string command = Console.ReadLine();

                matrix[startRow, startCol] = '.';

                if (command == "right")
                {

                    startCol += 1;

                    if (IsInside(matrix, startRow, startCol))
                    {
                        if (matrix[startRow, startCol] == '*')
                        {
                            quantutyFood++;
                        }

                        else if (matrix[startRow, startCol] == 'B')
                        {
                            matrix[startRow, startCol] = '.';
                            for (int i = 0; i < burrowsPosition.Count; i += 2)
                            {
                                if (startRow != burrowsPosition[i] && startCol != burrowsPosition[i + 1])
                                {
                                    startRow = burrowsPosition[i];
                                    startCol = burrowsPosition[i + 1];
                                }
                            }
                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        isOutside = true;
                    }
                }
                else if (command == "left")
                {
                    startCol -= 1;

                    if (IsInside(matrix, startRow, startCol))
                    {
                        if (matrix[startRow, startCol] == '*')
                        {
                            quantutyFood++;
                        }

                        else if (matrix[startRow, startCol] == 'B')
                        {
                            matrix[startRow, startCol] = '.';

                            for (int i = 0; i < burrowsPosition.Count; i += 2)
                            {
                                if (startRow != burrowsPosition[i] && startCol != burrowsPosition[i + 1])
                                {
                                    startRow = burrowsPosition[i];
                                    startCol = burrowsPosition[i + 1];
                                }
                            }
                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        isOutside = true;
                    }

                }
                else if (command == "down")
                {
                    startRow += 1;

                    if (IsInside(matrix, startRow, startCol))
                    {
                        if (matrix[startRow, startCol] == '*')
                        {
                            quantutyFood++;
                        }
                        else if (matrix[startRow, startCol] == 'B')
                        {
                            matrix[startRow, startCol] = '.';
                            for (int i = 0; i < burrowsPosition.Count; i += 2)
                            {
                                if (startRow != burrowsPosition[i] && startCol != burrowsPosition[i + 1])
                                {
                                    startRow = burrowsPosition[i];
                                    startCol = burrowsPosition[i + 1];
                                }
                            }
                        }
                        matrix[startRow, startCol] = 'S';

                    }
                    else
                    {
                        isOutside = true;
                    }

                }
                else if (command == "up")
                {
                    startRow -= 1;

                    if (IsInside(matrix, startRow, startCol))
                    {
                        if (matrix[startRow, startCol] == '*')
                        {
                            quantutyFood++;
                        }

                        else if (matrix[startRow, startCol] == 'B')
                        {
                            matrix[startRow, startCol] = '.';

                            for (int i = 0; i < burrowsPosition.Count; i += 2)
                            {
                                if (startRow != burrowsPosition[i] && startCol != burrowsPosition[i + 1])
                                {
                                    startRow = burrowsPosition[i];
                                    startCol = burrowsPosition[i + 1];
                                }
                            }
                        }
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        isOutside = true;
                    }
                }
            }
            if (isOutside)
            {
                Console.WriteLine("Game over!");
            }
            if (quantutyFood == NEED_FOOD)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {quantutyFood}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static void InitialiseMatrix(char[,] matrix, ref int startRow, ref int startCol, List<int> burrowsPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    FindStartPosition(matrix, ref startRow, ref startCol, row, col);

                    FindBurrowsPoints(matrix, burrowsPosition, row, col);
                }
            }
        }

        private static void FindBurrowsPoints(char[,] matrix, List<int> burrowsPosition, int row, int col)
        {
            if (matrix[row, col] == 'B')
            {
                burrowsPosition.Add(row);
                burrowsPosition.Add(col);
            }
        }

        private static void FindStartPosition(char[,] matrix, ref int startRow, ref int startCol, int row, int col)
        {
            if (matrix[row, col] == 'S')
            {
                startRow = row;
                startCol = col;
            }
        }
    }
}
