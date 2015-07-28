//  Task 4
//  Create a class Path to hold a sequence of points in the 3D space.

namespace T1to4Geometry
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Path
    {
        //  Field
        private List<Point3D> pathOfPoints;

        //  Constructors
        public Path()
        {
            this.pathOfPoints = new List<Point3D>();
        }

        public Path(params Point3D[] points)
            :this()
        {
        for (int i = 0; i < points.Length; i++)
			{
			 this.pathOfPoints.Add(points[i]);
			}
        }

        //  properties
        public List<Point3D> PathOfPoints
        {
            get
            {
                return new List<Point3D> (this.pathOfPoints);
            }
        }

        //  Аdd a point method
        public void AddPoint(Point3D point)
        {
            this.pathOfPoints.Add(point);
        }



        public override string ToString()
        {
        return String.Join(", ", PathOfPoints);
        }
    }
}
