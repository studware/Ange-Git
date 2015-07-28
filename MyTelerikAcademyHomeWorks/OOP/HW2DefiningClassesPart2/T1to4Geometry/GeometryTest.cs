

namespace T1to4Geometry
{
    using System;
    
    public class GeometryTest
    {
        static void Main()
        {
            //  Tasks 1, 2
            Console.WriteLine("Start point of the coordinate system: {0}", Point3D.Point0);
            Point3D point1 = new Point3D(2,3,4);
            Console.WriteLine("Point1: {0}", point1);
            Point3D point2 = new Point3D(-4, 2, -4.5);
            Console.WriteLine("Point2: {0}\n", point2);

            //  Task 3
            Console.WriteLine("Distance of point1 from the start point: {0}", Distance3D.CalculateDistance(point1, Point3D.Point0));
            Console.WriteLine("Distance of point2 from the start point: {0}", Distance3D.CalculateDistance(point2, Point3D.Point0));
            Console.WriteLine("Distance between point1 and point2: {0}\n", Distance3D.CalculateDistance(point1, point2));

            //  Task 4
            Path path = new Path(Point3D.Point0, point1);
            path.AddPoint(point2);
            path.AddPoint(new Point3D(1.9, 25, -14.9));
            Console.WriteLine("Path of points: \n{0}", path);

            PathStorage.SavePath(path, "../../PathBackup.txt");

            Console.WriteLine("\nThe sample path was saved in the file PathBackup.txt\n");

            Console.WriteLine("The sample path loaded from the file PathBackup.txt:\n");

            Path loadedPath = PathStorage.LoadPath("../../PathBackup.txt");

            for (int i = 0; i < loadedPath.PathOfPoints.Count; i++)
            {
                Console.WriteLine(loadedPath.PathOfPoints[i].ToString());
            }
        }
    }
}
