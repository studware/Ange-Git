using System;
class CompareArrays
{
    static void Main()
    {
        Console.WriteLine("Compare two arrays element by element");
        string inputVar;
        uint n;
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        double[] arr1 = new double[n];
        double[] arr2 = new double[n];
        bool[] compare = new bool[n];
        bool result = true;

        Console.WriteLine("Now enter the elements of the first array:");

        for (int i = 0; i < n; i++)
        {
            compare[i] = true;
            arr1[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the elements of the second array:");

        for (int i = 0; i < n; i++)
        {
            arr2[i] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine("Result:");
        for (int i = 0; i < n; i++)
        {
            if (arr1[i] != arr2[i])
            {
                compare[i] = false;
                result = false;
            }
            Console.WriteLine(" {0,15} = {1,15} ?\t{2}",arr1[i],arr2[i],compare[i]);
        }
        Console.WriteLine("Are both arrays equal? {0}",result);
    }
}
