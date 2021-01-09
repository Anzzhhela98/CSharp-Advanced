using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperChecker = w => w[0] == w.ToUpper()[0];


            string[] text = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Where(upperChecker)
                          .ToArray();
            Console.Write(String.Join(Environment.NewLine, text));


        }
    }
}
