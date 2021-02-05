using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();



















            //var torba = new Dictionary<string, Dictionary<string, long>>();
            //long zlato = 0;
            //long kamuni = 0;
            //long mangizi = 0;

            //for (int i = 0; i < wealth.Length; i += 2)
            //{
            //    string name = wealth[i];
            //    long broika = long.Parse(wealth[i + 1]);

            //    string kvoE = string.Empty;

            //    if (name.Length == 3)
            //    {
            //        kvoE = "Cash";
            //    }
            //    else if (name.ToLower().EndsWith("gem"))
            //    {
            //        kvoE = "Gem";
            //    }
            //    else if (name.ToLower() == "gold")
            //    {
            //        kvoE = "Gold";
            //    }

            //    if (kvoE == "")
            //    {
            //        continue;
            //    }
            //    else if (capacityOfBag < torba.Values.Select(x => x.Values.Sum()).Sum() + broika)
            //    {
            //        continue;
            //    }

            //    switch (kvoE)
            //    {
            //        case "Gem":
            //            if (!torba.ContainsKey(kvoE))
            //            {
            //                if (torba.ContainsKey("Gold"))
            //                {
            //                    if (broika > torba["Gold"].Values.Sum())
            //                    {
            //                        continue;
            //                    }
            //                }
            //                else
            //                {
            //                    continue;
            //                }
            //            }
            //            else if (torba[kvoE].Values.Sum() + broika > torba["Gold"].Values.Sum())
            //            {
            //                continue;
            //            }
            //            break;
            //        case "Cash":
            //            if (!torba.ContainsKey(kvoE))
            //            {
            //                if (torba.ContainsKey("Gem"))
            //                {
            //                    if (broika > torba["Gem"].Values.Sum())
            //                    {
            //                        continue;
            //                    }
            //                }
            //                else
            //                {
            //                    continue;
            //                }
            //            }
            //            else if (torba[kvoE].Values.Sum() + broika > torba["Gem"].Values.Sum())
            //            {
            //                continue;
            //            }
            //            break;
            //    }

            //    if (!torba.ContainsKey(kvoE))
            //    {
            //        torba[kvoE] = new Dictionary<string, long>();
            //    }

            //    if (!torba[kvoE].ContainsKey(name))
            //    {
            //        torba[kvoE][name] = 0;
            //    }

            //    torba[kvoE][name] += broika;
            //    if (kvoE == "Gold")
            //    {
            //        zlato += broika;
            //    }
            //    else if (kvoE == "Gem")
            //    {
            //        kamuni += broika;
            //    }
            //    else if (kvoE == "Cash")
            //    {
            //        mangizi += broika;
            //    }
            //}

            //foreach (var x in torba)
            //{
            //    Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            //    foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            //    {
            //        Console.WriteLine($"##{item2.Key} - {item2.Value}");
            //    }
            //}
        }
    }
}