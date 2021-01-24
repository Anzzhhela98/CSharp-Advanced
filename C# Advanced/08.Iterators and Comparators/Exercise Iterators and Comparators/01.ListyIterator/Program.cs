using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputInfo = Console
                      .ReadLine()
                      .Split(" ")
                      .Skip(1)
                      .ToList();

            ListyIterator<string> listyIterator =
                new ListyIterator<string>(inputInfo);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    bool boolean = listyIterator.Move();
                    Console.WriteLine(boolean);
                }
                else if (command == "HasNext")
                {
                    bool boolean = listyIterator.HasNext();
                    Console.WriteLine(boolean);
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }
                else if (command== "PrintAll")
                {
                    foreach (var person in listyIterator)
                    {
                        Console.Write(person + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
