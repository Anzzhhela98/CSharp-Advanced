namespace Bakery.Models.Drinks.Contracts
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50M;
        public Water(string name, int portion, string brand)
            : base(name, portion, WaterPrice, brand)
        {

        }
    }
}
