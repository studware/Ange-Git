using System;

namespace Algo2.ColorRabbits
{
    internal class ColorRabbits
    {
        private static void Main()
        {
            //  Telerik Algo Academy, Oct 2012 - Color Rabbits task (word file included in the homework .rar file)

            //  get input data
            int countOfAskedrabbits = int.Parse(Console.ReadLine());
            int[] replies = new int[countOfAskedrabbits];

            for (int i = 0; i < countOfAskedrabbits; i++)
            {
                replies[i] = int.Parse(Console.ReadLine());
            }
            int minimalNumberOfRabbits = MinimumRabbits(replies);
            Console.WriteLine(minimalNumberOfRabbits);
        }

/// <summary>
/// Finds the minimal count of rabbits in a forest if given some quantities of equally colored rabbits 
/// </summary>
/// <param name="replies">these are the given quantities of equally colored rabbits</param>
/// <returns>minCount - the minimal count of rabbits in the forest</returns>
        
        private static int MinimumRabbits(int[] replies)
        {
            int[] rabbitsByColor = new int[1000002];
            for (int i = 0; i < replies.Length; i++)
            {
                rabbitsByColor[replies[i] + 1]++;
            }
            int minCount = 0;
            for (int i = 0; i < rabbitsByColor.Length; i++)
            {
                if (rabbitsByColor[i] == 0) continue;
                if (rabbitsByColor[i] <= i) minCount += i;
                else minCount += (int) Math.Ceiling((double)rabbitsByColor[i]/i)*i;
            }
            return minCount;
        }
    }
}

