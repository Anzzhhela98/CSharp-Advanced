using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowAndCols = Console
                          .ReadLine()
                          .Split(", ")
                          .Select(int.Parse)
                          .ToArray();
            int[] firstLineNum = new int[2];
            int[] secondLineNum = new int[2];

            int[,] matrix = ReadMatrix(rowAndCols[0], rowAndCols[1]);
            int maxSquareSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = 0;
                    currSum += matrix[row, col] + matrix[row + 1, col]
                            + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (maxSquareSum < currSum)
                    {
                        maxSquareSum = currSum;
                        firstLineNum[0] = matrix[row, col];
                        firstLineNum[1] = matrix[row, col + 1];

                        secondLineNum[0] = matrix[row + 1, col];
                        secondLineNum[1] = matrix[row + 1, col + 1];
                    }
                }
            }
            Console.WriteLine(string.Join(" ", firstLineNum));
            Console.WriteLine(string.Join(" ", secondLineNum));
            Console.WriteLine(maxSquareSum);
            static int[,] ReadMatrix(int rows, int cols)
            {
                int[,] matrix = new int[rows, cols];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int[] rowDate = Console
                               .ReadLine()
                               .Split(", ")
                               .Select(int.Parse)
                               .ToArray();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = rowDate[col];
                    }
                }
                return matrix;
            }

        }
    }
}
