using System;

/// <summary>
/// The class Point describes a point in a 2D Cartesian Counter-clockwise
/// system and methods for calculating the coordinates in rotation around the Z-axis.
/// It can be upgraded with more methods for transformation calculations
/// (reflection, translation, etc.)
/// </summary>
public class Point
{
    private double initialX;
    private double initialY;

    public Point(double initialX, double initialY)
    {
        this.InitialX = initialX;
        this.InitialY = initialY;
    }

    public double InitialX
    {
        get { return this.initialX; }
        set { this.initialX = value; }
    }

    public double InitialY
    {
        get { return this.initialY; }
        set { this.initialY = value; }
    }

    /// <summary>
    /// Method to rotate points in the XY-Cartesian plane counter-clockwise through a given angle.
    /// </summary>
    /// <param name="point">Point object.</param>
    /// <param name="rotationAngle">Transformation angle in degrees.</param>
    /// <returns>Returns new Point object which is the original point rotated around the Z-axis.</returns>
    public static Point GetRotatedPoint(Point point, double rotationAngle)
    {
        double angleInRadians = rotationAngle * Math.PI / 180;
        double sine = Math.Abs(Math.Sin(angleInRadians));
        double cosine = Math.Abs(Math.Cos(angleInRadians));
        double rotatedX = cosine * point.InitialX - sine * point.InitialY;
        double rotatedY = sine * point.InitialX + cosine * point.InitialY;
        Point result = new Point(rotatedX, rotatedY);
        return result;
    }
}