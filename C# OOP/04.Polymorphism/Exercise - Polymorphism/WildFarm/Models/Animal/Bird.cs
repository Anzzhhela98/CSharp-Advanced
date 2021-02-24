
namespace WildFarm.Models.Animal
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $" {WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
