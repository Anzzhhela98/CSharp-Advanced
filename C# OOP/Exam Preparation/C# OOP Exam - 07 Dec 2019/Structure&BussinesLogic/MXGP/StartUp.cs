using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.Core.Contracts;
    using MXGP.Repositories;

    public class StartUp
    {
        

        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();


           

        }
    }
}
