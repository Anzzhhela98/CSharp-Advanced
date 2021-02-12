using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var thread = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int numberToKill = int.Parse(Console.ReadLine());

            bool isKilled = false;

            while (!isKilled)
            {

                int currentTask = task.Peek();
                int currentTread = thread.Peek();

                if (currentTask == numberToKill)
                {
                    Console.WriteLine($"Thread with value {currentTread} killed task {numberToKill}");
                    isKilled = true;
                    break;
                }
                else if (currentTread >= currentTask)
                {
                    task.Pop();
                }

                thread.Dequeue();
            }
            Console.WriteLine(String.Join(" ", thread));
        }
    }
}
