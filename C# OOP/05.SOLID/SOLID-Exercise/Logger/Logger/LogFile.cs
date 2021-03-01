using System;
using System.IO;
using System.Linq;
namespace Logger.Logger
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
        public int Size { get; set; }

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message + Environment.NewLine);
            this.Size = message.ToCharArray().Where(char.IsLetter).Sum(x => x);
        }
    }
}
