using System;
using System.Text;

namespace _01.RhombusOfStars
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var rhombusPrinter =
                new RhombusPrinter(size);

            Console.WriteLine(rhombusPrinter.Print(size));



        }
    }
}
