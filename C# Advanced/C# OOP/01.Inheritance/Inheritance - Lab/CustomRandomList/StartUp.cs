using System;

namespace CustomRandomList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Ina");
            list.Add("Pina");
            list.Add("Ina");
            list.Add("Shina");
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}
