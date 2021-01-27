using System;
namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("1");
            stack.Push("17");
            stack.Push("7");

            Console.WriteLine(stack.IsEmpty());

            Console.WriteLine(string.Join(" ", stack.AddRange()));

        }
    }
}
