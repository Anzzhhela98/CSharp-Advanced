using System;
using System.Text;

namespace _01.ClassBoxData.Common
{
    public class Box
    {
        private const int Min_Box_Side = 0;
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.Length = length;
            }

            private set
            {
                ValidateState(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.Width = width;
            }

            private set
            {
                ValidateState(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.Height = height;
            }

            private set
            {
                ValidateState(value, nameof(this.Height));
                this.height = value;
            }
        }
        public double CalculateSurfaceArea()
        {
            double surfaceArea =
                (2 * this.length * this.width) + (2 * this.height * this.Length) + (2 * this.width * this.height);
            return surfaceArea;
        }
        public double CalculateLateralSurfaceArea()
        {
            double lateraralSurfaceArea =
                   (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return lateraralSurfaceArea;
        }

        public double CalculateVolum()
        {
            double volum = this.length * this.height * this.width;
            return volum;
        }
        private void ValidateState(double value, string type)
        {
            if (value <= Min_Box_Side)
            {
                throw new ArgumentException
               (String.Format(GlobalConstants.ExepsionInvalidParameters, type));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {CalculateSurfaceArea():F2}");

            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():f2}");

            sb.AppendLine($"Volume - {CalculateVolum():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
