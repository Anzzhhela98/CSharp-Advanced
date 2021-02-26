using _MilitaryElite.Contracts;
using _MilitaryElite.Exeptions;
using _MilitaryElite.IO.Contracts;
using _MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;
        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = this.reader.ReadLine()) != "End")
            {

                string[] cmndArgs = command
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();

                string soldierType = cmndArgs[0];
                int id = int.Parse(cmndArgs[1]);
                string firstName = cmndArgs[2];
                string lastName = cmndArgs[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(cmndArgs, id, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddLieutenantGeneral(cmndArgs, id, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmndArgs[4]);

                    string corps = cmndArgs[5];

                    try
                    {
                        soldier = CreateEngineer(cmndArgs, id, firstName, lastName, salary, corps);
                    }
                    catch (InvalidCorpsExeption ice)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmndArgs[4]);
                    string corps = cmndArgs[5];

                    try
                    {
                        ICommando commando = GetCommando(cmndArgs, id, firstName, lastName, salary, corps);

                        soldier = commando;
                    }
                    catch (InvalidCorpsExeption ice)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmndArgs[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                if (soldier != null)
                {
                    this.soldiers.Add(soldier);

                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier CreateEngineer(string[] cmndArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            string[] repairArgs = cmndArgs
                                .Skip(6)
                                .ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
            }
            soldier = engineer;
            return soldier;
        }

        private static ICommando GetCommando(string[] cmndArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            string[] misiionArgs = cmndArgs
                                 .Skip(6)
                                 .ToArray();

            for (int i = 0; i < misiionArgs.Length; i += 2)
            {
                try
                {
                    string missionCodeName = misiionArgs[i];
                    string missionState = misiionArgs[i + 1];

                    IMission misiion = new Mission(missionCodeName, missionState);

                    commando.AddMission(misiion);
                }
                catch (InvalidMissionStateExeption imse)
                {
                    continue;
                }
            }

            return commando;
        }


        private ISoldier AddLieutenantGeneral(string[] cmndArgs, int id, string firtName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmndArgs[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firtName, lastName, salary);

            foreach (var pID in cmndArgs.Skip(5))
            {
                ISoldier privateToAdd =
                    this.soldiers.First(x => x.Id == int.Parse(pID));

                general.AddPrivate(privateToAdd);
            }

            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] cmndArgs, int id, string firtName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmndArgs[4]);
            soldier = new Private(id, firtName, lastName, salary);
            return soldier;
        }
    }
}
