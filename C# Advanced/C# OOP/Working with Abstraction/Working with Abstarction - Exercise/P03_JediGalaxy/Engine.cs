using System;
using System.Linq;

namespace P03_JediGalaxy
{
    static class Engine
    {
        public static void Run()
        {
            int[] dimensions = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            Matrix matrix = new Matrix(dimensions[0], dimensions[1]);

            string command = string.Empty;

            int sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] playerCordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Player Ivo = new Player(playerCordinates[0], playerCordinates[1]);

                int[] evilCordinates = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Player Evil = new Player(evilCordinates[0], evilCordinates[1]);

                while (Evil.Row >= 0 && Evil.Col >= 0)
                {
                    if (Evil.Row < matrix.Row && Evil.Col < matrix.Col)
                    {
                        matrix.MatrixTemplate[Evil.Row, Evil.Col] = 0;
                    }

                    Evil.MakeZerosToTopLefDiagonal();
                }

                while (Ivo.Row >= 0 && Ivo.Col < matrix.Row)
                {
                    if (Ivo.Row >= 0 && Ivo.Row < matrix.Col && Ivo.Col >= 0 && Ivo.Col < matrix.Row)
                    {
                        sum += matrix.MatrixTemplate[Ivo.Row, Ivo.Col];
                    }

                    Ivo.CollectStarsToTopRighttDiagonal();
                }
            }
            Console.WriteLine(sum);
        }
    }
}
