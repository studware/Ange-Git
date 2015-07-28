using System;
using System.Collections.Generic;

public class SortStringsArrayByLengths
{
    class StrLengthsComparer : IComparer<string>
    {
        public int Compare(string strElem1, string strElem2)
        {
            int strLength1 = strElem1.Length;
            int strLength2 = strElem2.Length;
            return strLength1.CompareTo(strLength2);
        }
    }

    static void Main()
    {
/*        string[] strArray = { "apple", "cherry", "sour cherry", "apricot", "plum", "banana", "orange", "raspberry" };*/
        Console.WriteLine("Write a method to sort a string array by the length of its elements");
        Console.Write("Enter the array size N: ");
        int n = int.Parse(Console.ReadLine());
        string[] strArray = new string[n];
        Console.WriteLine("Enter the elements of the array: ");
        for (int i = 0; i < n; i++)
        {
            strArray[i] = Console.ReadLine();
        }

        Array.Sort(strArray, new StrLengthsComparer());
        Console.WriteLine("The sorted array by string lengths ascending:");
        foreach (string strElement in strArray)
        {
            Console.WriteLine(strElement);
        }
    }
}

