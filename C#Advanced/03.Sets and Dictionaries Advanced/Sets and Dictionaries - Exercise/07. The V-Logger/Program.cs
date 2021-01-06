using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmilConrad joined The V-Logger 

            // VenomTheDoctor joined The V-Logger

            //Saffrona joined The V-Logger

            //Saffrona followed EmilConrad


            Dictionary<string, Dictionary<string, SortedSet<string>>> vlogers =
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputInfo = input
                              .Split(" ")
                              .ToArray();


                if (inputInfo[1] == "joined")
                {
                    string vloggerName = inputInfo[0];

                    if (!vlogers.ContainsKey(vloggerName))
                    {
                        vlogers.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        vlogers[vloggerName].Add("following", new SortedSet<string>());
                        vlogers[vloggerName].Add("followers", new SortedSet<string>());
                    }

                }
                else if (inputInfo[1] == "followed")
                {
                    string firstVlogger = inputInfo[0];
                    string secondVlogger = inputInfo[2];
                    if (vlogers.ContainsKey(firstVlogger) && vlogers.ContainsKey(secondVlogger))
                    {
                        if (vlogers[firstVlogger] != vlogers[secondVlogger]) //Vlogger cannot follow himself 
                        {

                            vlogers[firstVlogger]["following"].Add(secondVlogger);
                            vlogers[secondVlogger]["followers"].Add(firstVlogger);

                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            int count = 1;

            var orderedVloger = vlogers
               .OrderByDescending(x => x.Value["followers"].Count)
               .ThenBy(x => x.Value["following"].Count)
               .ToDictionary(x => x.Key, v => v.Value);

            foreach (var vloger in orderedVloger)
            {
                Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value["followers"].Count} followers," +
                    $" {vloger.Value["following"].Count} following");
                if (count == 1)
                {
                    foreach (var followers in vloger.Value["followers"])
                    {
                        
                        Console.WriteLine($"*  {followers}");

                    }
                }
                    count++;
            }
        }
    }
}
