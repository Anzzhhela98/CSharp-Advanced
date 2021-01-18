using System;
using System.Diagnostics;

namespace CustomDataStructers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new CustomList();


            for (int i = 0; i < 10; i++)
            {
                list.Add(i);

            }
            ;
            //Debug.Assert(list[2] == 9);
        }
    }
}
