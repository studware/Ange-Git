namespace T1to4Geometry
{
    using System;

    //  Task 3 - static cklass to calculate distance between two 2D points
    static class Distance3D
    {
        //  static method

        public static double CalculateDistance(Point3D p, Point3D q) 
        {
            double distX=p.X-q.X;
            double distY=p.Y-q.Y;
            double distZ=p.Z-q.Z;

            return Math.Sqrt(distX*distX+distY*distY+distZ*distZ);
        }
    }
}
