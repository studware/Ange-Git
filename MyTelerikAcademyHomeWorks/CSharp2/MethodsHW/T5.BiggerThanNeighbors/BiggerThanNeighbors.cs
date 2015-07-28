using System;

class BiggerThanNeighbors
{
    static bool BiggerNeighbors(int elem,int[] arr)
    {
        return (arr[elem - 1] < arr[elem]) && (arr[elem] > arr[elem + 1]);
    }
    
    static void Main()
        {
            Console.WriteLine("Check if element at given position in given array of integers\nis bigger than its two neighbors (when such exist).");
            string strNum;
            int n;
            int checkPos;

            Console.WriteLine("Enter array length n > 2: ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter array elements:");
            int[] intArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            do
            {
                Console.Write("Enter the element position, >= 1 and <={0}: ", n-2);
            }
            while (!int.TryParse(strNum = Console.ReadLine(), out checkPos) || checkPos < 1 || checkPos > n-2);

            Console.WriteLine("The element at position {0} is bigger than its neighbors: {1}", checkPos,BiggerNeighbors(checkPos,intArray));
        }
}
