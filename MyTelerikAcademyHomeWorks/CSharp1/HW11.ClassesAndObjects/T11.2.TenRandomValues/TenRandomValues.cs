using System;

class TenRandomValues
{
    static void Main()
    {
        Console.WriteLine("Generate and print to the console 10 random values in the range [100, 200]:");

        int[] random=new int[10];

        Random randGenerator=new Random();

        for (int i = 0; i < 10; i++)
        {
            random[i] = randGenerator.Next(100, 200) + 1;
            Console.Write("{0}, ",random[i]);
        }
        Console.WriteLine();
    }
}
