using System;
using System.Linq;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personName = Console
                           .ReadLine()
                           .Split()
                           .ToArray();
            string[] nameAndAmountBeer = Console
                          .ReadLine()
                          .Split()
                          .ToArray();
            double[] integerAndDoubleNum = Console
                          .ReadLine()
                          .Split()
                          .Select(double.Parse)
                          .ToArray();
            string concatName = personName[0] +" "+ personName[1];
            var tuple1 = new Tuple<string, string>(concatName, personName[2]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(nameAndAmountBeer[0], int.Parse(nameAndAmountBeer[1]));
            Tuple<double, double> tuple3 = new Tuple<double, double>(integerAndDoubleNum[0], integerAndDoubleNum[1]);
               

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);

        }
    }
}
