using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P05_GreedyTimes
{
    class Engine
    {
        private Bag bag;
        public void Run()
        {
            this.bag = new Bag(decimal.Parse(Console.ReadLine()));
            string[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string goldPattern = @"\b(?i)gold\b";
            string gemPattern = @"\b(?i)[a-z0-9]{1,}gem\b";
            string cashPatern = @"\b(?i)[a-z]{3}\b";

            for (int i = 0; i < tokens.Length; i += 2)
            {
                string item = tokens[i];
                long quantity = long.Parse(tokens[i + 1]);

                Match goldMatch = Regex.Match(item, goldPattern);
                Match gemMatch = Regex.Match(item, gemPattern);
                Match cashMatch = Regex.Match(item, cashPatern);

                if (goldMatch.Success)
                {
                    Gold goldItem = new Gold(goldMatch.Value, quantity);
                    this.bag.AddGoldItem(goldItem);
                }
                else if (gemMatch.Success)
                {
                    Gem gemItem = new Gem(gemMatch.Value, quantity);
                    this.bag.AddGemItem(gemItem);

                }
                else if (cashMatch.Success)
                {
                    Cash cashItem = new Cash(cashMatch.Value, quantity);
                    this.bag.AddCashItem(cashItem);
                }
            }

            if (!String.IsNullOrEmpty(this.bag.ToString()))
            {
                Console.WriteLine(this.bag);
            }
        }
    }
}