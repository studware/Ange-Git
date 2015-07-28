namespace T1And2.Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;
        
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius cannot be negative.");
                }

                this.radius = value; 
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }
}
