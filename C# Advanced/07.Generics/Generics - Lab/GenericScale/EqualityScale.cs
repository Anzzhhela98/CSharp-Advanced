namespace GenericScale
{
    public class EqualityScale<T>
    {
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T Left { get; set; }
        public T Right { get; set; }
        public bool AreEqual()
        {
            if (this.Left.Equals(this.Right))
            {
                return true;
            }
            return false;
        }
    }
}
