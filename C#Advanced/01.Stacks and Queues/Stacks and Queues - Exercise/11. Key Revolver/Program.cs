using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> lokcs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int allMoney = int.Parse(Console.ReadLine());

            int barrel = sizeGunBarrel;
            while (lokcs.Any() && bullets.Any())
            {
                int currBullet = bullets.Peek(); // kуршуми
                int currLokcs = lokcs.Peek(); // ключалки
                if (currBullet <= currLokcs)
                {
                    Console.WriteLine("Bang!");
                    lokcs.Dequeue();
                    sizeGunBarrel--;
                    allMoney -= bulletPrice;
                }
                else
                {
                    sizeGunBarrel--;
                    allMoney -= bulletPrice;
                    Console.WriteLine("Ping!");
                }

                bullets.Pop(); // премахваме куршума и в двата случая
                if (bullets.Count == 0 && lokcs.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {lokcs.Count}");
                    return;
                }
                else if (bullets.Count == 0 && lokcs.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${allMoney}");
                    return;
                }
                if (sizeGunBarrel == 0)
                {
                    sizeGunBarrel = barrel;
                    if (bullets.Count > 0)
                    {
                        
                        Console.WriteLine("Reloading!");
                    }
                }
            }
            if (lokcs.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${allMoney}");
                return;
            }

        }
    }
}
