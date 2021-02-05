namespace Animals
{
    public class Tomcat : Animal
    {
        private const string TomcatGender = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, TomcatGender)
        {

        }
        public override string ProduceSound()
        {
            string sound = "MEOW";
            return sound;
        }
    }
}
