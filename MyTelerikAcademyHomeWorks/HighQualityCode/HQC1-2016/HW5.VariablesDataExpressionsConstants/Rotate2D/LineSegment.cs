using System;

/// <summary>
/// The class LineSegment describes a line segment in a 2D Cartesian Counter-clockwise
/// system and methods for calculating its projections on the X- and Y - axes after rotation around the Z-axis.
/// It can be upgraded with more methods for transformation calculations
/// (reflection, translation, etc.)
/// </summary>
public class LineSegment
{
    private double projectionX;
    private double projectionY;

    public LineSegment(double projectionX, double projectionY)
    {
        this.ProjectionX = projectionX;
        this.ProjectionY = projectionY;
    }

    public double ProjectionX
    {
        get { return this.projectionX; }
        set { this.projectionX = value; }
    }

    public double ProjectionY
    {
        get { return this.projectionY; }
        set { this.projectionY = value; }
    }

    /// <summary>
    /// Method to rotate line segments in the XY-Cartesian plane counter-clockwise through a given angle.
    /// </summary>
    /// <param name="lineSegment">Line Segment object.</param>
    /// <param name="transformeAngle">Transformation angle in degrees.</param>
    /// <returns>Returns new LineSegment object which is the original point rotated around the Z-axis.</returns>
    public static LineSegment GetTransformedRectangle(LineSegment lineSegment, double rotationAngle)
    {
        double angleInRadians = rotationAngle * Math.PI / 180;
        double rotatedProjX = Math.Abs(Math.Cos(angleInRadians)) * lineSegment.ProjectionX + Math.Abs(Math.Sin(angleInRadians)) * lineSegment.ProjectionY;
        double rotatedProjY = Math.Abs(Math.Sin(angleInRadians)) * lineSegment.ProjectionX + Math.Abs(Math.Cos(angleInRadians)) * lineSegment.ProjectionY;

        LineSegment result = new LineSegment(rotatedProjX, rotatedProjY);

        return result;
    }
}