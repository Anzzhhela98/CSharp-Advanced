namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Bark();
            puppy.Eat();
            puppy.Weep();

            Animal animal = new Animal();
            animal.Eat();

            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();
        }
    }
}
