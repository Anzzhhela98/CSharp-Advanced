using System;

namespace _02.GenericBoxofInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
