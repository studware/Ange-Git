using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.ShortestSequence
{
    public class ShortestSequence
    {
        public delegate int Delegates(int number);

        static void Main()
        {
            Console.WriteLine("Find the shortest sequence of operations that starts from N and finishes in M.\nHint: use a queue");
            Console.WriteLine("Operations: N=N+1; N=N+2; N=N*2");

            Queue<OperationResult> operationResults = new Queue<OperationResult>();
            OperationResult currentItem, tempItem;
            int startNumber = 0, endNumber = 0;
            Delegates[] operations = new Delegates[]
            {
                new Delegates(Operations.OperationAddOne),
                new Delegates(Operations.OperationAddTwo),
                new Delegates(Operations.OperationMultiplyByTwo)
            };
     
            Console.Write("Enter start number N = ");
            startNumber = int.Parse(Console.ReadLine());
     
            Console.Write("Enter end number M = ");
            endNumber = int.Parse(Console.ReadLine());
     
            currentItem.Result = startNumber;
            currentItem.Generation = string.Empty;
            operationResults.Enqueue(currentItem);
     
            tempItem.Result = 0;
            tempItem.Generation = string.Empty;
     
            while (operationResults.Count > 0 && tempItem.Result != endNumber)
            {
                currentItem = operationResults.Dequeue();
                if (currentItem.Generation == String.Empty)
                {
                    tempItem.Generation = currentItem.Result.ToString();
                }
                else
                {
                    tempItem.Generation = currentItem.Generation + " -> " + currentItem.Result;
                }
     
                for (int i = 0; i < operations.Length; i++)
                {
                    tempItem.Result = operations[i](currentItem.Result);
                    if (tempItem.Result == endNumber)
                    {
                        break;
                    }
                    else if (tempItem.Result < endNumber)
                    {
                        operationResults.Enqueue(tempItem);
                    }
                }
            }
     
            if (tempItem.Result == endNumber)
            {
                Console.WriteLine("The shortest path from N to M is: {0} -> {1}", tempItem.Generation, tempItem.Result);
            }
            else
            {
                Console.WriteLine("No solution!");
            }
        }
    }
}

