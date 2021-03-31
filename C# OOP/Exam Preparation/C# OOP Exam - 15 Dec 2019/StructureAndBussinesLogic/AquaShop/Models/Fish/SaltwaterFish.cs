namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int INITIAL_SIZE = 5;
        private const int EAT_INCREASE_SIZE = 2;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = INITIAL_SIZE;
        }

        public override void Eat()
        {
            this.Size += EAT_INCREASE_SIZE;
        }
    }
}
