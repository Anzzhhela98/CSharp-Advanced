using System;
using _MilitaryElite.IO.Contracts;
namespace _MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
