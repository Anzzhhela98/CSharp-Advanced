namespace AquaShop.Models.Aquariums.Models
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int INITAL_CAPACITY = 25;
        public FreshwaterAquarium(string name) 
            : base(name, INITAL_CAPACITY)
        {

        }
    }
}
