namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int INITIAL_COMFORT = 1;
        private const decimal INITIAL_PRICE = 5;
        public Ornament() : base(INITIAL_COMFORT, INITIAL_PRICE)
        {

        }
    }
}
