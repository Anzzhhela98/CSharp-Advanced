namespace P01_RawData
{
   public class Car
    {
        public Car(string model, Engine engine,
           Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }


        public string Model { get; private set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
        public Cargo Cargo { get; private set; }
    }
}
