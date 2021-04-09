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

            this.computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfExist(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component = typeOfComponent switch
            {
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            this.computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            this.components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfExist(computerId);

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            Enum.TryParse(peripheralType, out PeripheralType typeOfPeripheral);
            IPeripheral peripheral = typeOfPeripheral switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),

                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            this.computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer bestComputer = this.computers.Where(x => x.Price <= budget).OrderByDescending(x => x.OverallPerformance).FirstOrDefault();

            if (bestComputer==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(bestComputer);
            return bestComputer.ToString();
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

            IComputer computerToBuy = this.computers.FirstOrDefault(x => x.Id == id);
            this.computers.Remove(computerToBuy);

            return computerToBuy.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfExist(computerId);

            IComponent componetToRemove = this.computers.FirstOrDefault(x => x.Id == computerId).RemoveComponent(componentType);
            this.components.Remove(componetToRemove);

            return String.Format(SuccessMessages.RemovedComponent, componentType, componetToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfExist(computerId);

            IPeripheral peripheralToRemove = this.computers.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralToRemove.Id);
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
