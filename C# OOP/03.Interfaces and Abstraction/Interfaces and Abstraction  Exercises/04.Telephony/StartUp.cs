using _04.Telephony.Contract;
using _04.Telephony.Model;
using System;
using System.Linq;

namespace _04.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] numbers = ReadConsole();

            foreach (var num in numbers)
            {
                try
                {
                    if (num.Length == Common.Validator.NUMBER_IS_LONG)
                    {
                        Calling(num);
                    }
                    else
                    {
                        Dialing(num);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            string[] sites = ReadConsole();

            foreach (var url in sites)
            {
                try
                {
                    Browsing(url);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string[] ReadConsole()
        {
            return Console.ReadLine()
                          .Split(" ")
                          .ToArray();
        }

        private static void Calling(string num)
        {
            ICallable number = new Smartphone();

            Console.WriteLine(number.Calling(num));
        }

        private static void Dialing(string num)
        {
            ICallable number = new StationaryPhone();

            Console.WriteLine(number.Calling(num));
        }

        private static void Browsing(string url)
        {
            IBrowsing webSite = new Smartphone();

            Console.WriteLine(webSite.Browsing(url));
        }
    }
}
