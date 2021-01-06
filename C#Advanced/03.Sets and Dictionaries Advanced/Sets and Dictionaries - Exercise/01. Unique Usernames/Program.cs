using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            HashSet<string> userNames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                userNames.Add(name);

            }
            foreach (var name in userNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
