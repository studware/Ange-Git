//      Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.

namespace T1.Shapes
{
    public abstract class Shape
    {
        public double Width {get; set;}
        public double Height {get; set;}

        public Shape(double side)
        {
            this.Width = side;
            this.Height = side;
        }

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double CalculateSurface()
        {
            return 0.0;
        }
    }
}
