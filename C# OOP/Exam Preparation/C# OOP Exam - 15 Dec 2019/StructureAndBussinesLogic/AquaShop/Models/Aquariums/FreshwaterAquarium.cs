namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int INITIAL_CAPACITY = 1;
        public FreshwaterAquarium(string name)
            : base(name, INITIAL_CAPACITY)
        {

        }
    }
}
