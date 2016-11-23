using System;
using System.Collections.Generic;

namespace T5.RemoveNegativeNumbers
{

    public class RemoveNegativeUtil
    {
        /// <summary>
        /// removes all negative numbers from given LinkedList<double> and returns the result as new LinkedList<double>.
        /// </summary>
        /// <param name="numbersList">The given list of numbers</param>
        /// <returns>LinkedList<double> positiveOnly - contains the subsequence of positive numbers in the numbersList</returns>
        public static void PositiveNumbersSubSet(LinkedList<double> numbersList)
        {
            LinkedListNode<Double> listNode = numbersList.First;

            while (listNode!=null)
            {
                var nextNode = listNode.Next;
                if (listNode.Value < 0)
                {
                    numbersList.Remove(listNode);
                }
                listNode=nextNode;
            }
        }
    }
}