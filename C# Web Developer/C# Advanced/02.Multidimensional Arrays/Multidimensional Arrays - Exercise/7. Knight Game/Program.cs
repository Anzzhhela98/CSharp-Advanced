using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            char[,] chessBoard = ReadMatrix(dimensions, dimensions);

            int knightCount = 0;
            int killerRow = 0;
            int killerCol = 0;

            while (true)
            {
                int maxAttaaks = 0;
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        int currentAttacks = 0;
                        if (chessBoard[row, col] == 'K')
                        {
                            if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }
                            if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }
                        }
                        if (currentAttacks > maxAttaaks)
                        {
                            maxAttaaks = currentAttacks;
                            killerCol = col;
                            killerRow = row;
                        }
                    }
                }
                if (maxAttaaks > 0)
                {
                    chessBoard[killerRow, killerCol] = '0';
                    knightCount++;
                }
                else
                {
                    Console.WriteLine(knightCount);
                    break;
                }
            }
        }
        private static bool IsInside(char[,] chessBoard, int row, int column)
        {
            return row >= 0 && row < chessBoard.GetLength(0)
               && column >= 0 && column < chessBoard.GetLength(1);

        }
        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowDate = Console
                           .ReadLine()
                           .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
            return matrix;
        }
    }
}
