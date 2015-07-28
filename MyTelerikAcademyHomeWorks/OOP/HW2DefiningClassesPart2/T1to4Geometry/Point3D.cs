namespace T1to4Geometry
{
    using System;
    //  Task 1 - structure Point 3D
    public struct Point3D
    {
        private static readonly Point3D point0 = new Point3D(0.0, 0.0, 0.0);     //  Task 2
        
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public static Point3D Point0
        {
            get { return point0; }
        }
        
        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("{{{0,3},{1,3},{2,5}}}", this.X, this.Y, this.Z);
        }
    }
    
}
