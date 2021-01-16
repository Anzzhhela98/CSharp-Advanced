
namespace CarSalesman
{
    public class Engine
    {
        private string engineModel;
        private int power;
        private int displacment;
        private string efficency;
      

        public Engine(string engineModel, int power, 
            int displacment, string efficency)
        {
            EngineModel = engineModel;
            Power = power;
            Displacement = displacment;
            Efficency = efficency;
        }

        //EngineModel 
        public string EngineModel { get; set; }
        //Power
        public int Power { get; set; }
        //Displacement
        public int Displacement { get; set; }
        //Efficiency
        public string Efficency { get; set; }
    }
}
