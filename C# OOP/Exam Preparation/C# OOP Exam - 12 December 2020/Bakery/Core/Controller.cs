using System;
using System.Linq;
using System.Text;
using Bakery.Models.Tables;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Enums;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> bakedFoods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal totalIncome;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.totalIncome = 0M;
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            Enum.TryParse(type, out DrinkType drinkType);
            drink = drinkType switch
            {
                DrinkType.Tea => new Tea(name, portion, brand),
                DrinkType.Water => new Water(name, portion, brand)
            };

            string result = string.Empty;
            if (drink != null)
            {
                result = string.Format(OutputMessages.DrinkAdded, name, brand);
                this.drinks.Add(drink);
            }

            return result;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            Enum.TryParse(type, out BakedFoodType bakedFoodType);
            bakedFood = bakedFoodType switch
            {
                BakedFoodType.Bread => new Bread(name, price),
                BakedFoodType.Cake => new Cake(name, price)
            };
            string output = string.Empty;
            if (bakedFood != null)
            {
                output = string.Format(OutputMessages.FoodAdded, bakedFood.Name, bakedFood.GetType().Name);
                this.bakedFoods.Add(bakedFood);
            }

            return output;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            string result = string.Empty;
            Enum.TryParse(type, out TableType tableType);

            table = tableType switch
            {
                TableType.InsideTable => new InsideTable(tableNumber, capacity),
                TableType.OutsideTable => new OutsideTable(tableNumber, capacity)
            };

            string output = string.Empty;
            if (table != null)
            {
                output = string.Format(OutputMessages.TableAdded, tableNumber);
                this.tables.Add(table);
            }

            return output;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder(0);
            foreach (var table in tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            if (table != null)
            {
                decimal bill = table.GetBill();
                this.totalIncome += bill;
                table.Clear();
                sb.AppendLine($"Table: {tableNumber}")
                    .AppendLine($"Bill: {bill:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            string result = string.Empty;
            if (table == null)
            {
                return result = String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drink == null)
            {
                return result = String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return result = $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            string result = string.Empty;
            if (table == null)
            {
                return result = String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (food == null)
            {
                return result = String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return result = String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            string result = string.Empty;

            if (freeTable == null)
            {
                return result = String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            return result = String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }
    }
}
