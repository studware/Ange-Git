namespace T1.HelperMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class contains helper methods for different pusposes
    /// </summary>
    public static class HelperMethods
    {
        /// <summary>
        /// Format modifiers used when printing formatted string
        /// </summary>
        public enum FormatOptions
        {
            FixedPoint,
            Percent,
            AlignRight
        }

        /// <summary>
        /// The method calculates the area of a triangle using the Heron's formula
        /// using the triangle's 3 sides' lengths
        /// </summary>
        /// <param name="sideA">side A of the triangle</param>
        /// <param name="sideB">side B of the triangle</param>
        /// <param name="sideC">side C of the triangle</param>
        /// <returns>the triangle area</returns>
        public static double TriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return triangleArea;
        }

        /// <summary>
        /// The method converts one-digit number to string containing the digit name
        /// </summary>
        /// <param name="number">The number to convert</param>
        /// <returns>String containing the digit name</returns>
        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("The number is negative or contains more than one digit!");
            }
        }

        /// <summary>
        /// The method finds the maximal value in an array of integer numbers
        /// </summary>
        /// <param name="arrayOfIntegers">The array of integer numbers</param>
        /// <returns>Integer value - the maximal value in the input array</returns>
        public static int FindMax(params int[] arrayOfIntegers)
        {
            if (arrayOfIntegers == null || arrayOfIntegers.Length == 0)
            {
                throw new ArgumentException("The array of integers doesn't exist or is empty!");
            }

            int maxValue = arrayOfIntegers[0];
            
            for (int i = 1; i < arrayOfIntegers.Length; i++)
            {
                if (arrayOfIntegers[i] > maxValue)
                {
                    maxValue = arrayOfIntegers[i];
                }
            }

            return maxValue;
        }

        /// <summary>
        /// The method prints an object as a number using different format options
        /// </summary>
        /// <param name="number">the numeric object</param>
        /// <param name="printFormat">Enumeration of format options</param>
        public static void PrintAsNumber(object number, FormatOptions printFormat)
        {
            switch (printFormat)
            {
                case FormatOptions.FixedPoint:
                    {
                        Console.WriteLine("{0:f2} -> Fixed point", number);
                        return;
                    }

                case FormatOptions.Percent:
                    {
                        Console.WriteLine("{0:p0 -> Percent}", number);
                        return;
                    }

                case FormatOptions.AlignRight:
                    {
                        Console.WriteLine("{0,8} -> Align Right", number);
                        return;
                    }

                default:
                    throw new ArgumentException("Invalid format!");
            }
        }

        /// <summary>
        /// The method calculates the length of a line segment in 2D Cartesian
        /// given start and end points of the segment
        /// </summary>
        /// <param name="xPoint1">X-projection of the start point</param>
        /// <param name="yPoint1">Y-projection of the start point</param>
        /// <param name="xPoint2">X-projection of the end point</param>
        /// <param name="yPoint2">Y-projection of the end point</param>
        /// <param name="isHorizontal">Boolean output value: is the line horizontal?</param>
        /// <param name="isVertical">Boolean output value: is the line vertical?</param>
        /// <returns></returns>
        public static double LineSegmentLength(
            double xPoint1,
            double yPoint1,
            double xPoint2,
            double yPoint2,
            out bool isHorizontal,
            out bool isVertical)
        {
            isHorizontal = yPoint1 == yPoint2;
            isVertical = xPoint1 == xPoint2;

            double xSize = xPoint2 - xPoint1;
            double ySize = yPoint2 - yPoint1;

            double segmentLength = Math.Sqrt((xSize * xSize) + (ySize * ySize));

            return segmentLength;
        }

        /// <summary>
        /// Test method for the helper methods described above
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("The area of triangle (3, 4, 5) is: {0}\n", TriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));
////            Console.WriteLine(NumberToDigit(55));
            Console.WriteLine();

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            Console.WriteLine();

            PrintAsNumber(1.3, FormatOptions.FixedPoint);
            PrintAsNumber(0.75, FormatOptions.Percent);
            PrintAsNumber(2.30, FormatOptions.AlignRight);
            Console.WriteLine();

            bool isHorizontal, isVertical;
            Console.Write("Line Segment (x1=3, y1=-1; x2=3, y2=2.5)\nLength: ");
            Console.WriteLine(LineSegmentLength(3, -1, 3, 2.5, out isHorizontal, out isVertical));
            Console.WriteLine("Is the line segment horizontal? " + isHorizontal);
            Console.WriteLine("Is the line segment vertical? " + isVertical);

            Student peter = new Student("Peter", "Ivanov");
            peter.DateOfBirth = new DateTime(1992, 03, 17);
            peter.Town = "Sofia";

            Student stella = new Student("Stella", "Markova");
            stella.DateOfBirth = new DateTime(1993, 11, 03);
            stella.Town = "Vidin";
            stella.Comment = "gamer, high results";

            Console.WriteLine(
                "\n{0} older than {1}? -> {2}\n",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
