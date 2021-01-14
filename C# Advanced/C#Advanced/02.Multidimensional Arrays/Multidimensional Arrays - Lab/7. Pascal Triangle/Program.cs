using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int dataRow = int.Parse(Console.ReadLine());

            long[][] jagged = new long[dataRow][];
            int cols = 1;

            for (int row = 0; row < dataRow; row++)
            {
                jagged[row] = new long[cols];
                jagged[row][0] = 1;
                jagged[row][jagged[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int column = 1; column < jagged[row].Length - 1; column++)
                    {
                        long[] prevRow = jagged[row - 1];
                        long firstNum = prevRow[column];
                        long secondNum = prevRow[column - 1];
                        jagged[row][column] = firstNum + secondNum;
                    }
                }
                cols++;
            }
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int column = 0; column < jagged[row].Length; column++)
                {
                    Console.Write(jagged[row][column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
