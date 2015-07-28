using System;

/// <summary>
/// The program calculates statistical characteristics (min, max, average) of an array of doubles.
/// </summary>
public class Statistics
{
    /// <summary>
    /// The method Main() tests the methods for statistic calculations of a given array of doubles
    /// and prints the results to the console.
    /// </summary>
    public static void Main()
    {
        double[] statisticNumbers = new double[] { 5, 35.54, 98.6, 89, 23.54, 2.4, 98.23 };

        Console.WriteLine("Variables, Data Expressions and Constants Homework");

        Console.WriteLine("The Rotations' task was implemented as a class library");
        Console.WriteLine("Please, observe the code!\n");

        Console.WriteLine("Statistic numbers to be processed:\n"); 
        for (int i = 0; i < statisticNumbers.Length; i++)
        {
            Console.Write("{0} ", statisticNumbers[i]);
        }

        Console.WriteLine("\nCalculated statistics:");

        PrintStatistics(statisticNumbers);
    }

    /// <summary>
    /// This method methods prints to the console the results from statistic calculations
    ///  of a given array of double precision numbers.  
    /// </summary>
    /// <param name="statisticNumbers">Array of double precision statistical numbers.</param>
    public static void PrintStatistics(double[] statisticNumbers)
    {
        Console.WriteLine("Max number: {0}", CalcMax(statisticNumbers));

        Console.WriteLine("Min number: {0}", CalcMin(statisticNumbers));

        Console.WriteLine("Average: {0}", CalcAverage(statisticNumbers));
    }

    /// <summary>
    /// The method calculates the maximal value of the statisticNumbers array.
    /// </summary>
    /// <param name="statisticNumbers">Array of double precision statistical numbers.</param>
    /// <returns>The maximal value of the statisticNumbers array.</returns>
    public static double CalcMax(double[] statisticNumbers)
    {
        double max = statisticNumbers[0];
        for (int i = 1; i < statisticNumbers.Length; i++)
        {
            if (statisticNumbers[i] > max)
            {
                max = statisticNumbers[i];
            }
        }

        return max;
    }

    /// <summary>
    /// The method calculates the minimal value of the statisticNumbers array.
    /// </summary>
    /// <param name="statisticNumbers">Array of double precision statistical numbers.</param>
    /// <returns>The minimal value of the statisticNumbers array.</returns>
    public static double CalcMin(double[] statisticNumbers)
    {
        double min = statisticNumbers[0];
        for (int i = 1; i < statisticNumbers.Length; i++)
        {
            if (statisticNumbers[i] < min)
            {
                min = statisticNumbers[i];
            }
        }

        return min;
    }

    /// <summary>
    /// The method calculates the average value of the statisticNumbers array.
    /// </summary>
    /// <param name="statisticNumbers">Array of double precision statistical numbers.</param>
    /// <returns>The average value of the statisticNumbers array.</returns>
    private static double CalcAverage(double[] statisticNumbers)
    {
        double sum = 0;
        for (int i = 0; i < statisticNumbers.Length; i++)
        {
            sum += statisticNumbers[i];
        }

        double average = sum / statisticNumbers.Length;

        return average;
    }
}