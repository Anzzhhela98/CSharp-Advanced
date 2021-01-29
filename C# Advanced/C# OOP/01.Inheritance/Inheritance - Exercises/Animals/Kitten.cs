namespace Animals
{
    public class Kitten : Animal
    {
        private const string KittenCatGender = "Female";
        public Kitten(string name, int age)
            : base(name, age, KittenCatGender)
        {

        }
        public override string ProduceSound()
        {
            string sound = "Meow";
            return sound;
        }
    }
}
