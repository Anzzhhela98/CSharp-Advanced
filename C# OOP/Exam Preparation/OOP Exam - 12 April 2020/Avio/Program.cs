using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            int flight = int.Parse(Console.ReadLine());
            string flightName = "";
            int biggestPassengers = 0;
            string bigestFlightName = "";

            for (int i = 1; i <= flight; i++)
            {
                flightName = Console.ReadLine();

                int sum = 0;

                int count = 0;
                while (true)
                {
                    string passengers = Console.ReadLine();
                    if (passengers == "Finish")
                    {
                        break;
                    }

                    else
                    {
                        int number = int.Parse(passengers);
                        count++;
                        sum += number;
                    }

                }

                int average = sum / count;
                if (average>biggestPassengers)
                {
                    biggestPassengers = average;
                    bigestFlightName = flightName;
                }
                Console.WriteLine($"{flightName} : {average} passengers.");
            }
            Console.WriteLine($"{bigestFlightName} has most passengers per flight: {biggestPassengers} ");
        }
    }
}
