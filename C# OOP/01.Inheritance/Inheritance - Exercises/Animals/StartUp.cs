namespace Animals
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string type = string.Empty;

            Animal animal;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console
                          .ReadLine()
                          .Split(" ")
                          .ToArray();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                switch (type)
                {
                    case "Dog":
                        try
                        {
                            animal = new Dog(name, age, gender);
                            Console.WriteLine(animal.ToString());
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Cat":
                        try
                        {
                            animal = new Cat(name, age, gender);
                            Console.WriteLine(animal.ToString());
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Frog":
                        try
                        {
                            animal = new Frog(name, age, gender);
                            Console.WriteLine(animal.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Kittens":
                        try
                        {
                            animal = new Kitten(name, age);
                            Console.WriteLine(animal.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Tomcat":
                        try
                        {
                            animal = new Tomcat(name, age);
                            Console.WriteLine(animal.ToString());
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }
    }
}
