using System;
using System.Linq;

namespace _02.PointinRectangle
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] coordinates = Console
                          .ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

            Rectangle rectangle = new Rectangle(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int[] points = Console
                          .ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

                Point point = new Point(points[0], points[1]);
                Console.WriteLine(rectangle.Contains(point));
            }

        }
    }
}
