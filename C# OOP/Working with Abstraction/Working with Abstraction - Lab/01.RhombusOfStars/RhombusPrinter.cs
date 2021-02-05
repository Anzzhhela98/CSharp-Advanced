using System.Text;
namespace _01.RhombusOfStars
{
    public class RhombusPrinter
    {
        public int size;
        public RhombusPrinter(int size)
        {
            this.Size = size;
        }

        public int Size
        {
            get { return this.size; }
            set
            {
                if (value<0)
                {
                    System.Console.WriteLine("Size cannot be negative!");
                }
            }
        }

        public void PrintTopPart(StringBuilder sb, int size)
        {
            for (int i = 1; i <= size; i++)
            {
                sb.Append(new string(' ', size - i));
                AddStars(sb, i);
            }
        }
        public void PritBottomPart(StringBuilder sb, int size)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                sb.Append(new string(' ', size - i));
                AddStars(sb, i);
            }
        }
        public void AddStars(StringBuilder sb, int i)
        {
            for (int stars = 0; stars < i; stars++)
            {
                sb.Append("* ");
                if (stars < size - 1)
                {
                    sb.Append(' ');
                }
            }
            sb.AppendLine();
        }
        public string Print(int size)
        {
            StringBuilder sb = new StringBuilder();
            this.PrintTopPart(sb, size);
            this.PritBottomPart(sb, size);
            return sb.ToString();
        }
    }
}
