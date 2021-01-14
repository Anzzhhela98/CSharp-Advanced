using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console
                            .ReadLine()
                            .Split(", ",
                            StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            Print(array, CountArray, SumArray);
        }

        static void Print(int[] array,
            Func<int[], int> count, Func<int[], int> sum)
        {
            Console.WriteLine(count(array));
            Console.WriteLine(sum(array));
        }
        static int CountArray(int[] array)
        {
            return array.Length;
        }
        static int SumArray(int[] array)
        {
            return array.Sum();
        }
    }
}
