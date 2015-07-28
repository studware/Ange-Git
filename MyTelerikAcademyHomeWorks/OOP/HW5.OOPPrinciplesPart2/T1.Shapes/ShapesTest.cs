/*  
    Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (height * width for rectangle and height * width/2 for triangle).
    Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
    Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Square, Rectangle, Triangle) stored in an array.
*/

namespace T1.Shapes
{
using System;
using System.Collections.Generic;

    class ShapesTest
    {
        static void Main()
        {
            Rectangle rect1 = new Rectangle( 2.5,4);
            Square square1 = new Square(1.5);
            Triangle triangle1 = new Triangle(4.8, 5.5);
            Square square2 = new Square(38.6);
            Rectangle rect2 = new Rectangle( 16,5);
            Square square3 = new Square(100);
            Triangle triangle2 = new Triangle(27.8, 10);
            Triangle triangle3 = new Triangle(64,1.25);
            Square square4 = new Square(44.9);
            Rectangle rect3 = new Rectangle( 88.6,4);
            Square square5 = new Square(18);
            Triangle triangle4 = new Triangle(12.39, 5.5);
            Square square6 = new Square(3);
            Rectangle rect4 = new Rectangle( 4,4);
            Rectangle rect5 = new Rectangle( 5,4);

            List<Shape> shapes = new List<Shape>() { rect1, square1, triangle1, square2, rect2, square3, triangle2,
                                            triangle3, square4, rect3, square5, triangle4, square6, rect4, rect5};

            Console.WriteLine("Surfaces of different shapes:\n\n Shape\t\tDimensions\tSurface Calculated\n\n");

            foreach (var item in shapes)
            {
                string t=item.GetType().ToString().Substring(10);
                string d = (t.Equals("Square") ? item.Width.ToString() : (item.Width.ToString() + ";" + item.Height.ToString()));
                Console.WriteLine("{0,-10}\t{1,-16} {2}",t, d, item.CalculateSurface());  
            }
            Console.WriteLine();
        }
    }
}
