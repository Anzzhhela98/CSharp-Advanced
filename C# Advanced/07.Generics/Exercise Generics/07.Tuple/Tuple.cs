
namespace _07.Tuple
{
    public class Tuple<TItem1, TItem2>
    {
        public Tuple(TItem1 item1, TItem2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public TItem1 Item1 { get; set; }
        public TItem2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
