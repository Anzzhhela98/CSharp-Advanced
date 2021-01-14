using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroad
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command;
            bool crashCars = false;
            string crashedCar = string.Empty;
            int hitIndex = -1;

            int passedCars = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currGreenLight = greenLight;
                    while (cars.Any() && currGreenLight > 0)
                    {
                        string curentCar = cars.Peek();
                        int carLenght = curentCar.Length;

                        currGreenLight -= carLenght;

                        if (currGreenLight >= 0)
                        {
                            cars.Dequeue();
                            passedCars++;
                        }
                        else
                        {
                            int left = Math.Abs(currGreenLight);

                            if (left <= freeWindow)
                            {
                                cars.Dequeue();
                                passedCars++;
                            }
                            else
                            {
                                crashCars = true;
                                crashedCar = curentCar;
                                hitIndex = carLenght - left + freeWindow;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                if (crashCars)
                {
                    break;
                }
            }
            if (crashCars)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar}" +
                    $" was hit at {crashedCar[hitIndex]}.");
                return;
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
