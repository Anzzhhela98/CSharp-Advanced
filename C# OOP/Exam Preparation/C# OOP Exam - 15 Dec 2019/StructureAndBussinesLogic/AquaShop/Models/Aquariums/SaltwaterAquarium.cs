namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int INITIAL_CAPACITY = 25;
        public SaltwaterAquarium(string name)
            : base(name, INITIAL_CAPACITY)
        {

        }
    }
}
