
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public abstract class Bag new GolD
    {
        private List<Gold> gold;
        private List<Gem> gem;
        private List<Cash> cash;

        public Bag(decimal capacity)
        {
            this.Capacity = capacity;
            this.gold = new List<Gold>();
            this.gem = new List<Gem>();
            this.cash = new List<Cash>();
        }

        public decimal Capacity { get; set; }
        public IReadOnlyCollection<Gold> Gold => this.gold.AsReadOnly();
        public decimal GoldAmount => this.gold.Sum(g => g.Quantity);

        public IReadOnlyCollection<Gem> Gems => this.gem.AsReadOnly();
        public decimal GemsAmount => this.gem.Sum(g => g.Quantity);

        public IReadOnlyCollection<Cash> Cash => this.cash.AsReadOnly();
        public decimal CashAmount => this.cash.Sum(c => c.Quantity);
        public void AddGoldItem(Gold goldItem)
        {
            Gold goldy = this.gold.FirstOrDefault(gi => gi.Name == goldItem.Name);
            if (goldy == null && goldItem.Quantity + this.GoldAmount <= this.Capacity)
            {
                this.gold.Add(goldItem);
            }
            else if (goldItem.Quantity + this.GoldAmount <= this.Capacity)
            {
                goldy.Add(goldItem.Quantity);
            }
        }

        public void AddGemItem(Gold gemItem)
        {
            Gem gemy = this.gem.FirstOrDefault(gi => gi.Name == gemItem.Name);
            if (gemy == null && gemItem.Quantity + this.GemsAmount <= this.Capacity)
            {
                if (this.GoldAmount >= this.GemsAmount + gemItem.Quantity)
                {
                    this.gem.Add((Gem)gemItem);
                }
            }
            else if (gemItem.Quantity + this.GemsAmount <= this.Capacity)
            {
                if (this.GoldAmount >= this.GemsAmount + gemItem.Quantity)
                {
                    gemy.Add(gemItem.Quantity);
                }
            }
        }

        public void AddCashItem(Cash cashItem)
        {
            Cash cashy = this.cash.FirstOrDefault(ci => ci.Name == cashItem.Name);
            if (cashy == null && cashItem.Quantity + this.CashAmount <= this.Capacity)
            {
                if (this.GemsAmount >= this.CashAmount + cashItem.Quantity)
                {
                    this.cash.Add(cashItem);
                }
            }
            else if (cashItem.Quantity + this.CashAmount <= this.Capacity)
            {
                if (this.GemsAmount >= this.CashAmount + cashItem.Quantity)
                {
                    cashy.Add(cashItem.Quantity);
                }
            }
        }

    }
}
