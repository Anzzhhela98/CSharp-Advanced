using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueCups = new Queue<int>
                (Console.ReadLine().Split().Select(int.Parse));//cups
            Stack<int> stackBottles = new Stack<int>
                (Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;
            while (queueCups.Count > 0 && stackBottles.Count > 0)
            {
                int currCups = queueCups.Peek();
                int currBottle = stackBottles.Pop();
                if (currBottle - currCups >= 0)
                {
                    queueCups.Dequeue();
                    wastedWater += currBottle - currCups;
                }
                else
                {
                    while (currBottle < currCups)
                    {
                        currBottle += stackBottles.Pop();
                    }
                    wastedWater += currBottle - currCups;
                    queueCups.Dequeue();
                }
            }
            if (queueCups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueCups)}");
            }
            else if (stackBottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackBottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
