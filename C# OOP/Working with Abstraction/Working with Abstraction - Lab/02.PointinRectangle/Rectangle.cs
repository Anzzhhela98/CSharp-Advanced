

using System.Collections.Generic;

namespace _02.PointinRectangle
{
    public class Rectangle
    {
        public List<Point> Points { get; set; }
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {

            this.Points = new List<Point>()
            {
            new Point(topLeftX, topLeftY),
            new Point(bottomRightX, bottomRightY)
            };
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = this.Points[0].X <= point.X && this.Points[1].X >= point.X;
            bool isInVertical = this.Points[0].Y <= point.Y && this.Points[1].Y >= point.X;
            return isInHorizontal && isInVertical;
        }
    }
}
