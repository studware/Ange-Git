using System;
class CompareArraysLex
{
    static void Main()
    {
        Console.WriteLine("Compare two char arrays element by element lexicographically");
        string inputVar;
        uint n;
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        char[] arr1 = new char[n];
        char[] arr2 = new char[n];
        char[] compare = new char[n];
        bool result = true;

        Console.WriteLine("Now enter the elements of the first array:");

        for (int i = 0; i < n; i++)
        {
            compare[i] = '=';
            arr1[i] = char.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the elements of the second array:");

        for (int i = 0; i < n; i++)
        {
            arr2[i] = char.Parse(Console.ReadLine());
        }
        Console.WriteLine("Result:");
        for (int i = 0; i < n; i++)
        {
            if (arr1[i].CompareTo(arr2[i])<0)
            {
                compare[i] = '<';
                result = false;
            }
            else if (arr1[i].CompareTo(arr2[i]) > 0)
            {
                compare[i] = '>';
                result = false;
            }
            Console.WriteLine(" {0} {1} {2}", arr1[i], compare[i], arr2[i] );
        }
        Console.WriteLine("Are both arrays lexicographically equal? {0}", result);
    }
}
