using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> tasks =
                new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Queue<int> threads =
                new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int value = int.Parse(Console.ReadLine());

            bool isKilled = false;
            int thread = 0;

            while (!isKilled)
            {
                int task = tasks.Peek();
                thread = threads.Dequeue();
                if (task == value)
                {
                    isKilled = true;
                    tasks.Pop();
                    Console.WriteLine($"Thread with value {thread} killed task {value}");
                    continue;
                }
                if (thread >= task)
                {
                    tasks.Pop();
                }
            }
            Console.WriteLine($"{thread} {string.Join(" ", threads)}");
        }
    }
}
