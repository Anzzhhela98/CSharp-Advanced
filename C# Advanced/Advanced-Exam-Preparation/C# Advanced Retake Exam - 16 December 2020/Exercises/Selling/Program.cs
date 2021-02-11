using System;
using System.Linq;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCol = int.Parse(Console.ReadLine());
            FillMatrix(rowCol);

        }

        private static void FillMatrix(int rowCol)
        {
            char[,] matrix = new char[rowCol, rowCol];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                   
                }
            }
        }
    }
}
