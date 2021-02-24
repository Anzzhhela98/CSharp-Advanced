using WildFarm.Models.Food;

namespace WildFarm.Models.Animal.Contract
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        string ProduceSound();
        void Eat(IFood food);
    }
}
