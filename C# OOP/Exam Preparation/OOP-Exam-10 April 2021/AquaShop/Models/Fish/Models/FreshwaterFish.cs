namespace AquaShop.Models.Fish.Models
{
    public class FreshwaterFish : Fish
    {
        private const int INITAL_SIZE = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = INITAL_SIZE;
        }

        public override void Eat()
        {
            this.Size += INITAL_SIZE;
        }
    }
}
