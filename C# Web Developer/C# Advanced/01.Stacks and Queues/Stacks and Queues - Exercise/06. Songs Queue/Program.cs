using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console
                           .ReadLine()
                           .Split(", ",
                           StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();
            var queue = new Queue<string>(songs);

            while (queue.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine($"{string.Join(", ", queue)}");
                }
                else
                {
                    string currSong = command.Substring(4, command.Length - 4);
                    if (!queue.Contains(currSong))
                    {
                        queue.Enqueue(currSong);
                        continue;
                    }
                    Console.WriteLine($"{currSong} is already contained!");
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
