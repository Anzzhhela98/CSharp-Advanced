using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int countOfMovement = int.Parse(Console.ReadLine());
            int startRow = -1;
            int startCol = -1;

            InitialiseMatrix(matrix, ref startRow, ref startCol);

            bool isReachedFinishMark = false;
            for (int i = 0; i < countOfMovement; i++)
            {
                string movement = Console.ReadLine();

                if (movement == "right")
                {
                    matrix[startRow, startCol] = '-';
                    startCol += 1;
                    if (!Validate(matrix, startRow, startCol))
                    {
                        startCol = 0;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        startCol += 1;

                    }
                    else if (matrix[startRow, startCol] == 'T')
                    {
                        startCol -= 1;

                    }
                    if (!Validate(matrix, startRow, startCol))
                    {
                        startCol = size - 1;
                    }
                    if (matrix[startRow, startCol] == 'F')
                    {
                        isReachedFinishMark = true;
                        matrix[startRow, startCol] = 'f';
                        break;
                    }
                    matrix[startRow, startCol] = 'f';
                }
                else if (movement == "left")
                {
                    matrix[startRow, startCol] = '-';
                    startCol -= 1;
                    if (!Validate(matrix, startRow, startCol))
                    {
                        startCol = size - 1;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        startCol -= 1;

                    }
                    else if (matrix[startRow, startCol] == 'T')
                    {

                        startCol += 1;

                    }
                    if (!Validate(matrix, startRow, startCol))
                    {
                        startCol = size - 1;
                    }
                    if (matrix[startRow, startCol] == 'F')
                    {
                        isReachedFinishMark = true;
                        matrix[startRow, startCol] = 'f';
                        break;
                    }
                    matrix[startRow, startCol] = 'f';
                }
                else if (movement == "up")
                {
                    matrix[startRow, startCol] = '-';
                    startRow -= 1;

                    if (!Validate(matrix, startRow, startCol))
                    {
                        startRow = size - 1;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        startRow -= 1;

                    }
                    else if (matrix[startRow, startCol] == 'T')
                    {
                        startRow += 1;

                    }
                    if (!Validate(matrix, startRow, startCol))
                    {
                        startCol = size - 1;
                    }
                    if (matrix[startRow, startCol] == 'F')
                    {
                        isReachedFinishMark = true;
                        matrix[startRow, startCol] = 'f';
                        break;
                    }
                    matrix[startRow, startCol] = 'f';
                }
                else if (movement == "down")
                {
                    matrix[startRow, startCol] = '-';
                    startRow += 1;

                    if (!Validate(matrix, startRow, startCol))
                    {
                        startRow = 0;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        startRow += 1;

                    }
                    else if (matrix[startRow, startCol] == 'T')
                    {
                        startRow -= 1;

                    }
                    if (!Validate(matrix, startRow, startCol))
                    {
                        startCol = size - 1;
                    }
                    if (matrix[startRow, startCol] == 'F')
                    {
                        isReachedFinishMark = true;
                        matrix[startRow, startCol] = 'f';
                        break;
                    }
                    matrix[startRow, startCol] = 'f';
                }
            }
            if (isReachedFinishMark)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
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

        private static bool Validate(char[,] matrix, int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentCol >= 0 && currentCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private static void InitialiseMatrix(char[,] matrix, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                    FindStartPosition(matrix, ref startRow, ref startCol, row, col);
                }
            }
        }

        private static void FindStartPosition(char[,] matrix, ref int startRow, ref int startCol, int row, int col)
        {
            if (matrix[row, col] == 'f')
            {
                startRow = row;
                startCol = col;
            }
        }
    }
}
