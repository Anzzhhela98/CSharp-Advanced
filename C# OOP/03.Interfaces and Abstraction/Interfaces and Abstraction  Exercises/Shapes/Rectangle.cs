using System;
namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new String('*', this.width));

            for (int i = 0; i < this.height - 2; i++)
            {
                Console.WriteLine($"*{new String(' ', this.width - 2)}*");
            }

            Console.WriteLine(new String('*', this.width));
        }
    }
}
