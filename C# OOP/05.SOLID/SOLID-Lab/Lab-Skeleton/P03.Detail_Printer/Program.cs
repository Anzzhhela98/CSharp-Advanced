using P03.Detail_Printer.Contarcts;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();

            IEmployee employee = new Employee("Petar");
            IEmployee manager =
                new Manager("Ivan", new string[] { "Document first", "Document second" });

            employees.Add(employee);
            employees.Add(manager);

            DetailsPrinter details = new DetailsPrinter(employees);

            details.PrintDetails();
        }
    }
}
