namespace T1And2.Shapes
{
    using System;

    public class ShapesDemo
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(
                "I am a circle. " + "My perimeter is {0:f2}. My surface is {1:f2}.",
                circle.CalculatePerimeter(),
                circle.CalculateSurface());

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(
                "I am a rectangle. " + "My perimeter is {0:f2}. My surface is {1:f2}.",
                rect.CalculatePerimeter(),
                rect.CalculateSurface());
        }
    }
}