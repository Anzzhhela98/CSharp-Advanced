namespace AquaShop.Models.Aquariums.Models
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int INITAL_CAPACITY = 25;
        public SaltwaterAquarium(string name) 
            : base(name, INITAL_CAPACITY)
        {

        }
    }
}
