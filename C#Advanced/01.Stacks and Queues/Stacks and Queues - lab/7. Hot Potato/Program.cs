using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputNames = Console
                           .ReadLine()
                           .Split()
                           .ToArray();
            var queue = new Queue<string>(inputNames);
            int currIndex = 1;

            int toss = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                var currName = queue.Dequeue();
                if (currIndex == toss)
                {
                    Console.WriteLine($"Removed {currName}");
                    currIndex = 1;
                    continue;
                }
                queue.Enqueue(currName);
                currIndex++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
