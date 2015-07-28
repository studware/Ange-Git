namespace T3.Utilities
{
    using System;

    /// <summary>
    /// Represents a rectangular parallelepiped.
    /// </summary>
    public class Box
    {
        private double width;
        private double height;
        private double depth;
        
        public Box(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (this.width < 0)
                {
                    throw new ArgumentException("Width cannot be negative.");
                }

                this.width = value;
            }
        }

       public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (this.height < 0)
                {
                    throw new ArgumentException("Height cannot be negative.");
                }

                this.height = value;
            }
        }
        
        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (this.depth < 0)
                {
                    throw new ArgumentException("Depth cannot be negative.");
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcBodyDiagonal()
        {
            double distance = GeometryUtils.CalcDistanceToOrigin3D(this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistanceToOrigin2D(this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistanceToOrigin2D(this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistanceToOrigin2D(this.Height, this.Depth);
            return distance;
        }
    }
}