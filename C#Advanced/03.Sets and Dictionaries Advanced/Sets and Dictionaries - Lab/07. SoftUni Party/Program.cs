using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> Vip = new HashSet<string>();
            HashSet<string> Regular = new HashSet<string>();
            string number = string.Empty;
            while ((number = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(number[0]))
                {
                    Vip.Add(number);
                }
                else
                {
                    Regular.Add(number);
                }
            }
            string commingPeople = string.Empty;
            while ((commingPeople = Console.ReadLine()) != "END")
            {
                if (Vip.Contains(commingPeople))
                {
                    Vip.Remove(commingPeople);
                    continue;
                }
                Regular.Remove(commingPeople);
            }
            Console.WriteLine(Vip.Count + Regular.Count);

            foreach (var num in Vip)
            {
                Console.WriteLine(num);
            }
            foreach (var num in Regular)
            {
                Console.WriteLine(num);
            }
        }
    }
}
