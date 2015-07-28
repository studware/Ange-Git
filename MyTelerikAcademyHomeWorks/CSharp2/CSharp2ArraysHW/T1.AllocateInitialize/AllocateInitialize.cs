using System;
class AllocateInitialize
{
    static void Main()
    {
        int[] arr20 = new int[20];
        Console.WriteLine("Calculate and print an array of 20 numbers");
        for (int i = 0; i < 20; i++)
        {
            arr20[i] = 5 * i;
            Console.WriteLine("{0}\t{1}", i, arr20[i]);
        }

    }
}