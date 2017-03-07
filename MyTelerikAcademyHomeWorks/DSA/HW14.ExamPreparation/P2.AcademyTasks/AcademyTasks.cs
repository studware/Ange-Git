using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AcademyTasks
{
	static void Main()
	{
		//  read input data from the console and form the int[] pleasantness array
        string pleasantnessAsString = Console.ReadLine();
		int variety = int.Parse(Console.ReadLine());
		string[] pleasantnessParts = pleasantnessAsString.Split(new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries);
		int[] pleasantness = pleasantnessParts.Select(x => int.Parse(x)).ToArray();
        //  
		Console.WriteLine(minNumber(pleasantness, variety));
	}

	/// <summary>
	/// Finds the minimum elements of an int array with (range between the min and max element) >= (an integer value)
	/// </summary>
	/// <param name="pleasantness">The array of integer elements </param>
	/// <param name="variety">The value of difference to be reacherd</param>
    /// <returns>the min count of elements with range between the min and max element >= variety</returns>
    static int minNumber(int[] pleasantness, int variety)
	{
		int result = pleasantness.Length;
		for (int i = 0; i < pleasantness.Length; i++)
		{
			for (int j = i + 1; j < pleasantness.Length; j++)
			{
				int difference = Math.Abs(pleasantness[i] - pleasantness[j]);
				if (difference < variety)
				{
					continue;
				}
				int act = (i + 3) / 2;
				int k = (j - i);
				act += (k + 1) / 2;
				result = Math.Min(result, act);
			}
		}
		return result;
	} 
}
