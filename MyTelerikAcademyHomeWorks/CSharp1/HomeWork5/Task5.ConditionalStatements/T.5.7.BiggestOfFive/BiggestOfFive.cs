using System;

class BiggestOfFive
{
    static void Main()
    {
        Console.WriteLine("Please enter five numbers (on separate lines:)");
        int[] varNum = new int[5];
        for (int i=0; i<5; i++)
        {
            varNum[i] = int.Parse(Console.ReadLine());
        }
        int biggest = varNum[0];
        for (int i=1; i < 5; i++)
        {
            if(biggest<varNum[i])
            {
                biggest=varNum[i];
            }
        }
            Console.WriteLine("The biggest number is: {0}", biggest); ;
    }
}
