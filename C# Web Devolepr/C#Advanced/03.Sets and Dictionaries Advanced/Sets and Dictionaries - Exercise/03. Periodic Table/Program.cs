using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueChemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {

                string[] chemicalCompounds = Console
                           .ReadLine()
                           .Split()
                           .ToArray();

                foreach (var Compound in chemicalCompounds)
                {
                    uniqueChemicalCompounds.Add(Compound.ToString());
                }
            }

            foreach (var Compound in uniqueChemicalCompounds)
            {
                Console.Write(Compound + " ");
            }
        }
    }
}
