using System;
using System.Linq;

namespace _02.Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int startRow = -1;
            int startCol = -1;
            FillMatrix(matrix, ref startRow, ref startCol);

            string command = string.Empty;
            string result = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                matrix[startRow, startCol] = '-';
                if (command == "left")
                {
                    startCol--;
                    if (!IsInside(matrix, startRow, startCol))
                    {
                        if (result.Any())
                        {
                            result = result.Remove(result.Length - 1);
                        }
                        startCol++;
                        matrix[startRow, startCol] = 'P';
                        continue;
                    }

                }
                else if (command == "right")
                {
                    startCol++;
                    if (!IsInside(matrix, startRow, startCol))
                    {
                        if (result.Any())
                        {
                            result = result.Remove(result.Length - 1);
                        }
                        startCol--;
                        matrix[startRow, startCol] = 'P';
                        continue;
                    }
                }
                else if (command == "up")
                {
                    startRow--;
                    if (!IsInside(matrix, startRow, startCol))
                    {
                        if (result.Any())
                        {
                            result = result.Remove(result.Length - 1);
                        }
                        startRow++;
                        matrix[startRow, startCol] = 'P';
                        continue;
                    }
                }
                else if (command == "down")
                {
                    startRow++;
                    if (!IsInside(matrix, startRow, startCol))
                    {
                        if (result.Any())
                        {
                            result = result.Remove(result.Length - 1);
                        }
                        startRow--;
                        matrix[startRow, startCol] = 'P';
                        continue;
                    }
                }

                char symbol = matrix[startRow, startCol];
                if (char.IsLetter(symbol))
                {
                    result += symbol;
                }
                matrix[startRow, startCol] = 'P';

            }

            Console.WriteLine(data+result);
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
        private static void FillMatrix(char[,] matrix, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
    }
}
