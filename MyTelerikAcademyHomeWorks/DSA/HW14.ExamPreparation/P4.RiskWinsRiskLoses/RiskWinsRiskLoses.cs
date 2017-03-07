using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

class RiskWinsRiskLoses
{
    /// <summary>
    /// Read the input parameters into appropriate variables and data structures and finds the best solution 
    /// </summary>
    static void Main()
    {
        string startCombination = Console.ReadLine();
        string finalCombination = Console.ReadLine();
        int forbiddenCombinationsCount = int.Parse(Console.ReadLine());
        //  Put all forbidden combinations into a List<string>
        List<string> forbiddenCombinations =
            new List<string>(forbiddenCombinationsCount);
        for (int i = 1; i <= forbiddenCombinationsCount; i++)
        {
            forbiddenCombinations.Add(Console.ReadLine());
        }

        //  Instantiate the finder class of the lowest buttons count 
        LowestButtonsCountFinder finder = new LowestButtonsCountFinder(
            startCombination, finalCombination, forbiddenCombinations);
        //  Find the best solution of the new 5-wheel based game
        Console.WriteLine(finder.Find() );
    }
}

/// <summary>
/// Finds the count of the lowest buttons
/// </summary>
class LowestButtonsCountFinder
{
    const int MaxNumber = 99999;
    const int WheelsCount = 5;
    private readonly int startEdge;
    private readonly int endEdge;
    private readonly bool[] isForbiddenEdge;
    private readonly int[] powerOf10;

    public LowestButtonsCountFinder(string startCombination, string finalCombination, List<string> forbiddenCombinations)
    {
        powerOf10 = new int[WheelsCount];
        powerOf10[0] = 1;
        for (int i = 1; i < WheelsCount; i++)
        {
            powerOf10[i] = powerOf10[i - 1] * 10;
        }
        this.startEdge = int.Parse(startCombination);
        this.endEdge = int.Parse(finalCombination);
        this.isForbiddenEdge = new bool[MaxNumber + 1]; // All false by default
        foreach (string forbiddenCombination in forbiddenCombinations)
        {
            this.isForbiddenEdge[int.Parse(forbiddenCombination)] = true;
        }
    }

    public int Find()
    {
        int result = BFS(this.startEdge, this.endEdge);
        return result;
    }
    
    /// <summary>
    /// Performs Breadth First Search using Queue structure
    /// </summary>
    /// <param name="startEdge">Start edge of the graph</param>
    /// <param name="endEdge">End edge of the graph</param>
    /// <returns></returns>
    private int BFS(int startEdge, int endEdge)
    {
        bool[] used = new bool[MaxNumber + 1];
        int level = 0;
        Queue<int> nodesQueue = new Queue<int>();
        nodesQueue.Enqueue(startEdge);
        while (nodesQueue.Count > 0)
        {
            Queue<int> nextLevelNodes = new Queue<int>();
            level++;
            while (nodesQueue.Count > 0)
            {
                int node = nodesQueue.Dequeue();
                if (node == endEdge)
                {
                    return level - 1;
                }

                // Pressing the left button
                for (int i = 0; i < WheelsCount; i++)
                {
                    int newNode = node;
                    int digit = (node / powerOf10[i]) % 10;
                    if (digit == 9)
                    {
                        newNode -= 9 * powerOf10[i];
                    }
                    else
                    {
                        newNode += powerOf10[i];
                    }
                    if (used[newNode]) continue;
                    if (isForbiddenEdge[newNode]) continue;
                    used[newNode] = true;
                    nextLevelNodes.Enqueue(newNode);
                }

                // Pressing the right button
                for (int i = 0; i < WheelsCount; i++)
                {
                    int newNode = node;
                    int digit = (node / powerOf10[i]) % 10;
                    if (digit == 0)
                    {
                        newNode += 9 * powerOf10[i];
                    }
                    else
                    {
                        newNode -= powerOf10[i];
                    }
                    if (used[newNode]) continue;
                    if (isForbiddenEdge[newNode]) continue;
                    used[newNode] = true;
                    nextLevelNodes.Enqueue(newNode);
                }
            }
            nodesQueue = nextLevelNodes;
        }
        return -1;
    }
}