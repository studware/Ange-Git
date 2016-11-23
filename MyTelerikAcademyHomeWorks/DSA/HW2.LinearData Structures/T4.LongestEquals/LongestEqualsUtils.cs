using System;
using System.Collections.Generic;

namespace T4.LongestEquals
{
    public class LongestEqualsUtils
    {
        /// <summary>
        /// Finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>.
        /// </summary>
        /// <param name="numbersList">The given list of integer numbers</param>
        /// <returns>List<int> longestEquals contains the longest subsequence of equal numbers in the numbersList</returns>
        public static List<int> LongestEqualNumbersSubSet(List<int> numbersList)
        {
            int index = 0;
            int number = 1;
            int indexNew = 0;
            int numberNew = 0;
            int currentIndex = 0;

            int count = numbersList.Count;
            while (currentIndex < count - 1)
            {
                indexNew = currentIndex;
                numberNew = 1;
                for (int j = indexNew; j < count - 1; j++)
                {
                    if (numbersList[j] == numbersList[j + 1])
                    {
                        numberNew++;
                        currentIndex++;
                    }
                    else
                    {
                        if (numberNew >= number)
                        {
                            index = indexNew;
                            number = numberNew;
                        }
                        break;
                    }
                }

                currentIndex++;
            }

            List<int> longestEquals = new List<int>();
            for (int i = index; i < index + number; i++)
            {
                longestEquals.Add(numbersList[i]);
            }
            return longestEquals;
        }
    }
}
