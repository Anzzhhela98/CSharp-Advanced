using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("..//..//..//input.txt");
            using (reader) 
            {
                int counter = 0;
                string line = reader.ReadLine();
                using (var writer = new StreamWriter("..//..//..//Output.txt"))
                {
                    while (line!=null)
                    {
                        if (counter%2==1)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
        
    }
}
