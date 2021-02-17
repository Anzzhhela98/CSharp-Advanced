using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int firstPlayerRow = 0;
            int firstPlayerCol = 0;

            int secondPlayerRow = 0;
            int secondPlayerCol = 0;

            FillMatrix(matrix, ref firstPlayerRow, ref firstPlayerCol, ref secondPlayerRow, ref secondPlayerCol);

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ");
                string firstCommand = commands[0];
                string secondCommand = commands[1];

                MovePlayer(size, matrix, ref firstPlayerRow, ref firstPlayerCol, firstCommand);
                if (matrix[firstPlayerRow, firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x';
                    break;
                }
                matrix[firstPlayerRow, firstPlayerCol] = 'f';


                MovePlayer(size, matrix, ref secondPlayerRow, ref secondPlayerCol, secondCommand);
                if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    break;
                }
                matrix[secondPlayerRow, secondPlayerCol] = 's';
            }
            Print(matrix);
        }

        private static void MovePlayer(int size, char[,] matrix, ref int row, ref int col, string command)
        {
            if (command == "right")
            {
                col++;
                if (!IsInside(matrix, row, col))
                {
                    col = 0;
                }
            }
            else if (command == "left")
            {
                col--;
                if (!IsInside(matrix, row, col))
                {
                    col = size - 1;
                }
            }
            else if (command == "up")
            {
                row--;
                if (!IsInside(matrix, row, col))
                {
                    row = size - 1;
                }
            }
            else if (command == "down")
            {
                row++;
                if (!IsInside(matrix, row, col))
                {
                    row = 0;
                }
            }
        }

        public static bool IsInside(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private static void FillMatrix(char[,] matrix, ref int firstPlayerRow, ref int firstPlayerCol, ref int secondPlayerRow, ref int secondPlayerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = data[col];
                    FindPlayersPosition(matrix, ref firstPlayerRow, ref firstPlayerCol, ref secondPlayerRow, ref secondPlayerCol, row, col);
                }
            }
        }

        private static void FindPlayersPosition(char[,] matrix, ref int firstPlayerRow, ref int firstPlayerCol, ref int secondPlayerRow, ref int secondPlayerCol, int row, int col)
        {
            if (matrix[row, col] == 'f')
            {
                firstPlayerRow = row;
                firstPlayerCol = col;
            }
            else if (matrix[row, col] == 's')
            {
                secondPlayerRow = row;
                secondPlayerCol = col;
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();

            }
        }
    }
}
