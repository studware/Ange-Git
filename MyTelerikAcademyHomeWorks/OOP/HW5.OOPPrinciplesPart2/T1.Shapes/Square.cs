//  Define class Square and suitable constructor so that at initialization height 
//  must be kept equal to width and implement the CalculateSurface() method.

namespace T1.Shapes
{
    public class Square : Shape
    {
        public Square(double side)
            : base(side)
        {

        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
