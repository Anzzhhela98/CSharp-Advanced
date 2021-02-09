using System;

namespace _03.Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDriveable car = new Ferrari(Console.ReadLine());

            Console.WriteLine(car.ToString());
        }
    }
}
