using System;

class TriangleSurface
{
    static void Main()
    {
        double aSide = 9.692;
        double ha = 5.382;  // altitude to side a
        double bSide = 8.39; 
        double cSide = 6.29;
        double angle = 0.2217*Math.PI;
        double triangleSurface;
        Console.WriteLine("Calculate the surface of a triangle by given:\n");
        triangleSurface=(aSide*ha)/2;
        Console.WriteLine("Side and an altitude to it: \n\t\t(aSide*ha)/2 = \t{0:##.##}\n",triangleSurface);

        double halfP = (aSide + bSide + cSide) / 2;
        triangleSurface=halfP*(halfP-aSide)*(halfP-bSide)*(halfP-cSide);
        triangleSurface = Math.Sqrt(triangleSurface);
        Console.WriteLine("Three sides: \nMath.Sqrt(p(p - a)(p - b)(p - c)) = {0:##.##} \n\twhere p = ½(a + b + c)\n", triangleSurface);

        triangleSurface=(aSide*bSide*Math.Sin(angle))/2;
        Console.WriteLine("Two sides and an angle between them:\n (aSide*bSide*Math.Sin(angle))/2 = {0:##.##}\n", triangleSurface);   
    }
}
