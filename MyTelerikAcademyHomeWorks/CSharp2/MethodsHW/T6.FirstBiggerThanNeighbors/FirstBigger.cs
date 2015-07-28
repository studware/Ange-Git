using System;

class FirstBiggerThanNeighbors
{
    static bool BiggerNeighbors(int elem, int[] arr)
    {
        return (arr[elem - 1] < arr[elem]) && (arr[elem] > arr[elem + 1]);
    }
    static int FrstBigNeighb(int[] arr)
    {
        int result=-1;
        for (int i = 1; i < arr.Length-1; i++)
        {
            if (BiggerNeighbors(i, arr))
            {
                result = i;
                return result;
            }
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Index of the first element in array that is bigger than its neighbors");
        int n;
        int indexPos;

        Console.Write("Enter array length n > 2: ");
        n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter array elements:");
        int[] intArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            intArray[i] = int.Parse(Console.ReadLine());
        }
        indexPos = FrstBigNeighb(intArray);
        if (indexPos == -1)
        {
            Console.WriteLine("There are no elements bigger than their neghbors.");
        }
        else
        {
            Console.WriteLine("Position of the first element that is bigger than its neighbors is: {0}", indexPos);
        }
    }
}
