using System;


namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int squereSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[squereSize, squereSize];

            int startRow = -1;
            int startCol = -1;

            int bonusRow = -1;
            int bonusCol = -1;

            int pollinatedFlowers = 0;

            FillMatrix(matrix, ref startRow, ref startCol, ref bonusRow, ref bonusCol);
            string command = string.Empty;

            bool IsOutSide = false;
            while ((command = Console.ReadLine()) != "End")
            {

                switch (command)
                {
                    case "up":
                        matrix[startRow, startCol] = '.';
                        startRow -= 1;
                        if (ValidateIndex(matrix, startRow, startCol))
                        {
                            if (matrix[startRow, startCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (matrix[startRow, startCol] == 'O')
                            {
                                matrix[startRow, startCol] = '.';
                                startRow -= 1;
                                if (matrix[startRow, startCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else
                        {
                            IsOutSide = true;
                        }
                        break;
                    case "down":
                        matrix[startRow, startCol] = '.';
                        startRow += 1;
                        if (ValidateIndex(matrix, startRow, startCol))
                        {

                            if (matrix[startRow, startCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (matrix[startRow, startCol] == 'O')
                            {
                                matrix[startRow, startCol] = '.';
                                startRow += 1;
                                if (matrix[startRow, startCol]=='f')
                                {
                                    pollinatedFlowers++;
                                }
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else
                        {
                            IsOutSide = true;
                        }
                        break;
                    case "left":
                        matrix[startRow, startCol] = '.';
                        startCol -= 1;
                        if (ValidateIndex(matrix, startRow, startCol))
                        {

                            if (matrix[startRow, startCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (matrix[startRow, startCol] == 'O')
                            {
                                matrix[startRow, startCol] = '.';
                                startCol += 1;
                                if (matrix[startRow, startCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else
                        {
                            IsOutSide = true;
                        }
                        break;
                    case "right":
                        matrix[startRow, startCol] = '.';
                        startCol += 1;
                        if (ValidateIndex(matrix, startRow, startCol))
                        {

                            if (matrix[startRow, startCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (matrix[startRow, startCol] == 'O')
                            {
                                matrix[startRow, startCol] = '.';
                                startCol += 1;
                                if (matrix[startRow, startCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                            }
                            matrix[startRow, startCol] = 'B';
                        }
                        else
                        {
                            IsOutSide = true;
                        }
                        break;
                }
                if (IsOutSide)
                {
                    break;
                }
            }
            if (IsOutSide)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            Print(matrix);
        }

        private static void Print(char[,] matrix)
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
        private static bool ValidateIndex(char[,] matrix, int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentCol >= 0 && currentCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private static void FillMatrix(char[,] matrix, ref int startRow, ref int startCol, ref int bonusRow, ref int bonusCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                    FindStartPosition(matrix, ref startRow, ref startCol, row, col);
                    FindBonusPosition(matrix, ref bonusRow, ref bonusCol, row, col);
                }
            }
        }
        private static void FindBonusPosition(char[,] matrix, ref int bonusRow, ref int bonusCol, int row, int col)
        {
            if (matrix[row, col] == 'О')
            {
                bonusRow = row;
                bonusCol = col;
            }
        }
        private static void FindStartPosition(char[,] matrix, ref int startRow, ref int startCol, int row, int col)
        {
            if (matrix[row, col] == 'B')
            {
                startRow = row;
                startCol = col;
            }
        }
    }
}
