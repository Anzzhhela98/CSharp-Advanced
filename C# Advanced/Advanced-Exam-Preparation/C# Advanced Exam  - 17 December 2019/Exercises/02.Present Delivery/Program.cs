using System;
using System.Linq;

namespace _02.Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresents = int.Parse(Console.ReadLine());

            int rowCol = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rowCol, rowCol];

            int startRow = -1;
            int startCol = -1;

            FillMatrix(matrix, ref startRow, ref startCol);

            int kids = matrix.Cast<string>().Where(x => x == "V").Count();
            int coutOfKids = kids;

            bool goesOutOfPResent = false;
            string command = string.Empty;

            while (countOfPresents > 0 && (command = Console.ReadLine()) != "Christmas morning")
            {
                if (command == "left")
                {
                    startCol -= 1;
                    if (IsInside(matrix, startRow, startCol))
                    {
                        matrix[startRow, startCol + 1] = "-";

                        if (matrix[startRow, startCol] == "V")
                        {
                            kids--;
                            countOfPresents--;
                        }
                        else if (matrix[startRow, startCol] == "C")
                        {
                            countOfPresents = ReceivePresent(countOfPresents, matrix, startRow, startCol,ref kids);
                        }
                        matrix[startRow, startCol] = "S";
                    }
                    else
                    {
                        goesOutOfPResent = true;
                        break;
                    }
                }
                else if (command == "right")
                {
                    startCol += 1;
                    if (IsInside(matrix, startRow, startCol))
                    {
                        matrix[startRow, startCol - 1] = "-";

                        if (matrix[startRow, startCol] == "V")
                        {
                            kids--;
                            countOfPresents--;
                        }
                        else if (matrix[startRow, startCol] == "C")
                        {
                            countOfPresents = ReceivePresent(countOfPresents, matrix, startRow, startCol, ref kids);
                        }
                        matrix[startRow, startCol] = "S";
                    }
                    else
                    {
                        goesOutOfPResent = true;
                        break;
                    }
                }
                else if (command == "up")
                {
                    startRow -= 1;
                    if (IsInside(matrix, startRow, startCol))
                    {
                        matrix[startRow + 1, startCol] = "-";

                        if (matrix[startRow, startCol] == "V")
                        {
                            kids--;
                            countOfPresents--;
                        }
                        else if (matrix[startRow, startCol] == "C")
                        {
                            countOfPresents = ReceivePresent(countOfPresents, matrix, startRow, startCol, ref kids);
                        }
                        matrix[startRow, startCol] = "S";
                    }
                    else
                    {
                        goesOutOfPResent = true;
                        break;
                    }
                }
                else if (command == "down")
                {
                    startRow += 1;
                    if (IsInside(matrix, startRow, startCol))
                    {
                        matrix[startRow - 1, startCol] = "-";

                        if (matrix[startRow, startCol] == "V")
                        {
                            kids--;
                            countOfPresents--;
                        }
                        else if (matrix[startRow, startCol] == "C")
                        {
                            countOfPresents = ReceivePresent(countOfPresents, matrix, startRow, startCol, ref kids);
                        }
                        matrix[startRow, startCol] = "S";
                    }
                    else
                    {
                        goesOutOfPResent = true;
                        break;
                    }
                }
            }
            if (goesOutOfPResent)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(matrix);

            if (kids == 0)
            {
                Console.WriteLine($"Good job, Santa! {coutOfKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {kids} nice kid/s.");
            }
        }
        private static void FillMatrix(string[,] matrix, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == "S")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static int ReceivePresent(int countOfPresents, string[,] matrix, int startRow, int startCol, ref int kids)
        {
            if (matrix[startRow, startCol - 1] == "V" || matrix[startRow, startCol - 1] == "X")
            {
                if (matrix[startRow, startCol - 1] == "V")
                {
                    kids--;
                }
                matrix[startRow, startCol - 1] = "-";
                countOfPresents--;
            }
            if (matrix[startRow, startCol + 1] == "V" || matrix[startRow, startCol + 1] == "X")
            {
                if (matrix[startRow, startCol + 1] == "V")
                {
                    kids--;
                }
                matrix[startRow, startCol + 1] = "-";
                countOfPresents--;
            }
            if (matrix[startRow + 1, startCol] == "V" || matrix[startRow + 1, startCol] == "X")
            {
                if (matrix[startRow + 1, startCol] == "V")
                {
                    kids--;
                }
                matrix[startRow + 1, startCol] = "-";
                countOfPresents--;
            }
            if (matrix[startRow - 1, startCol] == "V" || matrix[startRow - 1, startCol] == "X")
            {
                if (matrix[startRow - 1, startCol] == "V")
                {
                    kids--;
                }
                matrix[startRow - 1, startCol] = "-";
                countOfPresents--;
            }

            return countOfPresents;
        }
        private static bool IsInside(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
               && col >= 0 && col < matrix.GetLength(1);
        }
        private static void PrintMatrix(string[,] matrix)
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
    }
}
