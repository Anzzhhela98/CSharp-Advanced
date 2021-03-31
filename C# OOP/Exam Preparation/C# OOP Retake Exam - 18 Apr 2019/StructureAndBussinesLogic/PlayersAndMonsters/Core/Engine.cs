using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using System;
using System.Linq;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly ManagerController managerController;
        private readonly Writer writer;
        private readonly Reader reader;

        public Engine()
        {
            this.managerController = new ManagerController();
            this.writer = new Writer();
            this.reader = new Reader();
        }


        public void Run()
        {
            string inputArgs;
            while ((inputArgs = this.reader.ReadLine()) != "Exit")
            {
                string[] data = inputArgs.Split().ToArray();
                string command = data[0];
                string typeOrName = null;
                string name = null;
                if (command != "Report")
                {
                    typeOrName = data[1];
                    name = data[2];
                }
                try
                {
                    if (command == "AddPlayer")
                    {
                        this.writer.WriteLine(this.managerController.AddPlayer(typeOrName, name));
                    }
                    else if (command == "AddCard")
                    {
                        this.writer.WriteLine(this.managerController.AddCard(typeOrName, name));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        this.writer.WriteLine(this.managerController.AddPlayerCard(typeOrName, name));
                    }
                    else if (command == "Fight")
                    {
                        this.writer.WriteLine(this.managerController.Fight(typeOrName, name));
                    }
                    else if (command == "Report")
                    {
                        this.writer.WriteLine(this.managerController.Report());
                    }
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }
    }
}