using System;
using System.Linq;
using OnlineShop.Common.Enums;
using System.Collections.Generic;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Computers.Models;
using OnlineShop.Models.Products.Components.Models;
using OnlineShop.Models.Products.Peripherals.Models;
namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }


            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component = typeOfComponent switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddComponent(component);
            this.components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            Enum.TryParse(computerType, out ComputerType typeOfComputer);
            IComputer computer = typeOfComputer switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),

                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            Enum.TryParse(peripheralType, out PeripheralType typeOfPerihal);
            IPeripheral peripheral = typeOfPerihal switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            if (!this.computers.Any() || this.computers.Any(x => x.Price > budget))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers = this.computers.OrderByDescending(x => x.OverallPerformance).ToList();
            IComputer best = computers.FirstOrDefault(x => x.Price < budget);
            computers.Remove(best);

            return best.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfExist(id);

            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfExist(id);

            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfExist(computerId);

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            var component = computer.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(component.GetType().Name);
            this.components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfExist(computerId);

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            var perihal = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computer.RemovePeripheral(perihal.GetType().Name);
            this.peripherals.Remove(perihal);


            return string.Format(SuccessMessages.RemovedComponent, peripheralType, perihal.Id);
        }

        private void CheckIfExist(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
