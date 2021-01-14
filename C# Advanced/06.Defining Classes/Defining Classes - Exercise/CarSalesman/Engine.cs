namespace CarSalesman
{
    public class Engine
    {
        private string modelEngine;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string modelEngine, int power,
            int displacement, string efficiency)
        {
            ModelEngine = modelEngine;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        // displacement efficiency
        public string ModelEngine
        {
            get { return modelEngine; }
            set { modelEngine = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
