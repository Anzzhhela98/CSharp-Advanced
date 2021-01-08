using System;
using System.IO;

namespace _02._Line_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader("../../../Input.txt"))
            {

                using (var writen = new StreamWriter("../../../output.txt"))
                {
                    int counter = 1;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writen.WriteLine($"{counter}. {line}");
                        Console.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }

        }
    }
}
