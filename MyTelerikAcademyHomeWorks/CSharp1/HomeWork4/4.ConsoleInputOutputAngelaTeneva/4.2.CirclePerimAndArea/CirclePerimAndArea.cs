using System;

    
class CirclePerimAndArea
    {
        static void Main()
        {
            Console.Write("Enter circle radius: ");
            string strRad = Console.ReadLine();
            double radius = double.Parse(strRad);
            double perim = (double)2 * Math.PI * radius;
            double area = (double)Math.PI * radius * radius;
            Console.WriteLine("Circle perimeter = {0:F5}; circle area = {1:F5}", perim, area);
        }
    }
