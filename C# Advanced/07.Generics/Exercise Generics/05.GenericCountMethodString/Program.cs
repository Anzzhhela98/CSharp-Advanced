using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string element = Console.ReadLine();


                box.StoreElement.Add(element);
            }
            string compareElement = Console.ReadLine();
            Console.WriteLine(box.GreaterThan(compareElement));

        }
    }
}
