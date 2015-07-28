using System;

class CountInArray
{
	static int CntOfNumInArray (int num, int[] arr)
	{
		int cnt=0;;
		for (int i = 0; i < arr.Length; i++)
			{
			 if (num==arr[i])
			 {
				cnt++;
			 }
			}
		return cnt;  
	}
	
	static void Main()
	{
		string strNum;
		int n;
		int checkNum;
		int count;
		Console.WriteLine("Count how many times given number appears in given array");

		Console.WriteLine("Enter an integer number: ");
		checkNum=int.Parse(Console.ReadLine());

		do
		{
			Console.Write("Enter array length n > 1: ");
		}
		while (!int.TryParse(strNum = Console.ReadLine(), out n) || n <= 1);

		Console.WriteLine("Enter array elements:");
		int[] intArray = new int[n];
		for (int i = 0; i < n; i++)
		{
			intArray[i] = int.Parse(Console.ReadLine()); 
		}

		count=CntOfNumInArray (checkNum, intArray);

		Console.WriteLine("The number {0} appears {1} times in the array.", checkNum,count);
	}
}
