using _MilitaryElite.Core;
using _MilitaryElite.IO;
using _MilitaryElite.IO.Contracts;

namespace _MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
