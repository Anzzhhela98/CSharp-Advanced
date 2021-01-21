using System;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < count; i++)
            {
                double numebr = double.Parse(Console.ReadLine());



                box.StoreElement.Add(numebr);
            }
            double compareNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(box.GreaterThan(compareNumber));

        }
    }
}
