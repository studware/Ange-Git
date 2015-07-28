namespace T1And2.Shapes
{
    using System;

    public class Rectangle : Shape
    {
        private double width;
        private double height;
        
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            { 
                return this.width;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            { 
                return this.height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be negative.");
                }

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double area = this.Width * this.Height;
            return area;
        }
    }
}