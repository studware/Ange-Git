using System;

public class LoopRefactoring
{
    public static void Main()
    {
        int[] array = new int[100];
        Random rand = new Random();

        // Generate random numbers to fill array
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, 20);
        }

        int expectedValue = 15;
        bool isFound = false;
        for (int i = 0; i < 100; i++)
        {
            Console.Write("{0} ", array[i]);
            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    isFound = true;
                    break;
                }
            }
        }

        Console.WriteLine("\nExpected value: {0}", expectedValue);

        // More code here
        if (isFound)
        {
            Console.WriteLine("Value Found");
        }
        else
        {
            Console.WriteLine("Value Not Found");
        }
    }
}