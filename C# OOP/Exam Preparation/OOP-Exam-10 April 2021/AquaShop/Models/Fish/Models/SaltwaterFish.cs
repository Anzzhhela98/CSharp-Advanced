namespace AquaShop.Models.Fish.Models
{
   public class SaltwaterFish : Fish
    {
        private const int INITAL_SIZE = 5;
        private const int INCREASE_SIZE = 2;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = INITAL_SIZE;
        }

        public override void Eat()
        {
            this.Size += INCREASE_SIZE;
        }
    }
}
