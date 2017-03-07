using System;

class SwapIntegers
{
    static void Main()
    {
        int firstInt = 5;
        int secondInt = 10;
        int swapInt = firstInt;
        Console.WriteLine("firstInt: {0,5}\t secondInt: {1,5}", firstInt, secondInt);
        firstInt = secondInt;
        secondInt = swapInt;
        Console.WriteLine("After the swap:");
        Console.WriteLine("firstInt: {0,5}\t secondInt: {1,5}", firstInt, secondInt);
    }
}

