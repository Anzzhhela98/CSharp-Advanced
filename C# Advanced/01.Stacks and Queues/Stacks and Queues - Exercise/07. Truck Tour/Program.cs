using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int gasStation = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();
            FillQueue(gasStation, queue);
            List<int> point = new List<int>();
            int count = 0;
            while (true)
            {
                int FuelAmount = 0;
                bool foundPoint = true;
                for (int i = 0; i < gasStation; i++)
                {
                    int[] currPimp = queue.Dequeue();
                    FuelAmount += currPimp[0];
                    if (FuelAmount < currPimp[1])
                    {
                        foundPoint = false;
                    }
                    FuelAmount -= currPimp[1];

                    queue.Enqueue(currPimp);
                }
                if (foundPoint)
                {
                    break;
                }
                count++;
                queue.Enqueue(queue.Dequeue());

            }
            Console.WriteLine(count);
        }

        private static void FillQueue(int gasStation, Queue<int[]> queue)
        {
            for (int i = 0; i < gasStation; i++)
            {

                int[] amountAndDistance = Console
                           .ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();

                queue.Enqueue(amountAndDistance);

            }
        }
    }
}
