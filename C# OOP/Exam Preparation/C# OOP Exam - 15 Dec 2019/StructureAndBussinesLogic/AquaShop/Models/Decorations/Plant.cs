namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int INITIAL_COMFORT = 5;
        private const decimal INITIAL_PRICE = 10;
        public Plant() : base(INITIAL_COMFORT, INITIAL_PRICE)
        {

        }
    }
}
