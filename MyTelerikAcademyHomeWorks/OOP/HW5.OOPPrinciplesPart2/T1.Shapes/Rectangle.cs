//          Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure 

namespace T1.Shapes
{
    public class Rectangle : Shape
    {

        public Rectangle(double width, double height)
            : base(width, height)
        {

        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
