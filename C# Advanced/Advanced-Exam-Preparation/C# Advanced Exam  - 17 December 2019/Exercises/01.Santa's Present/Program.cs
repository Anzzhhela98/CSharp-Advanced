using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Santa_s_Present
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Doll = 150;
            const int WoodenTrain = 250;
            const int TeddyeBear = 300;
            const int Bicycle = 400;


            var materials = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var magicValues = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            
            var presents = new Dictionary<string, int>
            {
               {"Bicycle",0},
                {"Doll",0},
                {"Teddy bear",0},
                {"Wooden train",0},
            };


            while (magicValues.Count > 0 && materials.Count > 0)
            {
                int magicNum = magicValues.Peek();
                int materialNum = materials.Peek();

                int sum = magicNum * materialNum;

                if (sum == Doll || sum == WoodenTrain || sum == TeddyeBear || sum == Bicycle)
                {
                    if (sum == Doll)
                    {
                        presents["Doll"] += 1;
                    }
                    else if (sum == Bicycle)
                    {
                        presents["Bicycle"] += 1;
                    }
                    else if (sum == TeddyeBear)
                    {
                        presents["Teddy bear"] += 1;
                    }
                    else
                    {
                        presents["Wooden train"] += 1;
                    }
                    magicValues.Dequeue();
                    materials.Pop();
                }
                else
                {
                    if (sum < 0)
                    {
                        sum = materialNum + magicNum;
                        magicValues.Dequeue();
                        materials.Pop();

                        materials.Push(sum);
                    }
                    else if (sum == 0)
                    {
                        if (materialNum == 0)
                        {
                            materials.Pop();
                        }
                        if (magicNum == 0)
                        {
                            magicValues.Dequeue();
                        }
                        continue;
                    }
                    else
                    {
                        magicValues.Dequeue();
                        materials.Pop();

                        materials.Push(materialNum + 15);
                    }
                }
            }

            if ((presents.ContainsKey("Teddy bear") && presents.ContainsKey("Bycycle")) ||
                (presents.ContainsKey("Doll") && presents.ContainsKey("Wooden train")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magicValues.Count > 0)
            {
                Console.WriteLine($"Magic left:{string.Join(", ", magicValues)}");
            }

            foreach (var present in presents)
            {
                if (present.Value > 0)
                {
                    Console.WriteLine($"{present.Key}: {present.Value}");

                }
            }
        }
    }
}
