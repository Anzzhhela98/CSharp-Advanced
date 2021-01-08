using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordAndFrequency = new Dictionary<string, int>();
            string[] words = File.ReadAllText("../../../Words.txt").Split();

            using (var reader = new StreamReader("../../../Input.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] wordsInCurrentLine = line.ToLower()
                    .Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        foreach (var item in wordsInCurrentLine)
                        {
                            if (word == item)
                            {
                                if (!wordAndFrequency.ContainsKey(item))
                                {
                                    wordAndFrequency.Add(item, 0);
                                }
                                wordAndFrequency[item]++;
                            }
                        }
                    }
                    line = reader.ReadLine();
                }
            }
            using (StreamWriter writer = new StreamWriter("../../..Ooutput.txt"))
            {
                foreach (var item in wordAndFrequency.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
