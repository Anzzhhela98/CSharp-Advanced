using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    class Threeuple<TItem1, TItem2, TItem3>
    {
        public Threeuple(TItem1 item1, TItem2 item2, TItem3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public TItem1 Item1 { get; set; }
        public TItem2 Item2 { get; set; }
        public TItem3 Item3 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }

}
