using System;

class BinarySearch
{
    static void Main()
    {
        Console.WriteLine("Read and sort an array of N integers,\nand an integer K, and using the method Array.BinSearch()\nfind the largest number in the array which is ≤ K");
        Console.Write("Enter the array size N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter an integer number K: ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the array: ");
        for (int i = 0; i < n; i++)
        {
                arr[i] = int.Parse(Console.ReadLine());
        }

   /*     int k = -4;  
        int[] arr = {5,10,0,34,-2}; */

        Array.Sort(arr);

        if (k < arr[0])
        {
            Console.WriteLine("There is not any array element <= {0}", k);
        }
        else
        {
            int target = k;
            int index = 0;
            do
            {
                if (((index = Array.BinarySearch(arr, target)) >= 0))
                {
                    Console.WriteLine("The largest number which is <=K is equal to {0}", target);
                    break;
                }
                else
                {
                    if (target > arr[0])
                    {
                        target--;
                    }
                    else
                    {
                        Console.WriteLine("There is not any array element <= {0}", k);
                        break;
                    }
                }
            } while (true);
        }
    }
}
