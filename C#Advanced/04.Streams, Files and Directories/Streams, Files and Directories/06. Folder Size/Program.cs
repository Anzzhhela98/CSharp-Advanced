using System;
using System.IO;

namespace _06._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = 0;
            string directoryPath = Console.ReadLine();

            string[] files = Directory.GetFiles(directoryPath);
            for (int i = 0; i < files.Length; i++)
            {

                FileInfo infoForFile = new FileInfo(files[i]);
                Console.WriteLine($"{infoForFile.FullName} --> {infoForFile.Length} bytes");
                size += infoForFile.Length;
            }

            Console.WriteLine(size);
        }
    }
}
