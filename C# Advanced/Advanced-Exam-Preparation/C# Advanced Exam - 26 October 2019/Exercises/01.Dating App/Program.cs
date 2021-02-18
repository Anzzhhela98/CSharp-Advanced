using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {

            var male = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var female = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int countMaches = 0;

            while (male.Any() && female.Any())
            {
                int currMale = male.Peek();
                int currFemale = female.Peek();

                if (currMale == currFemale)
                {
                    male.Pop();
                    female.Dequeue();
                    countMaches++;
                    continue;
                }
                if (currFemale <= 0 || currMale <= 0)
                {
                    if (currMale <= 0)
                    {
                        male.Pop();
                    }
                    else
                    {
                        female.Dequeue();
                    }
                    continue;
                }
                else if (currMale % 25 == 0 || currFemale % 25 == 0)
                {
                    if (currMale % 25 == 0)
                    {
                        male.Pop();

                        if (male.Any())
                        {
                            male.Pop();
                        }
                    }
                    else
                    {
                        female.Dequeue();
                        if (female.Any())
                        {
                            female.Dequeue();
                        }
                    }
                    continue;
                }
                if (currMale != currFemale)
                {
                    female.Dequeue();
                    male.Pop();
                    male.Push(currMale - 2);
                }
            }
            Console.WriteLine($"Matches: {countMaches}");
            if (male.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", male)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (female.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", female)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
