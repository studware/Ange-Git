using System;
using System.Collections.Generic;
using System.Linq;

namespace T1.Algo1.FriendsOfPesho
{
    class FriendsOfPesho
    {
        /// <summary>
        /// Accept from the console input data about the graph;
        /// Finds the shortest path using the Dijkstra algorithm and prints at the console
        /// </summary>
        public static void Main()
        {
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            string[] initialParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfNodes = int.Parse(initialParams[0]);
            int numberOfStreets = int.Parse(initialParams[1]);
            int numberOfHospitals = int.Parse(initialParams[2]);

            string[] hospitalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] hospitalNumbers = new int[hospitalParams.Length];

            for (int i = 0; i < hospitalParams.Length; i++)
            {
                hospitalNumbers[i] = int.Parse(hospitalParams[i]);
            }

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            List<int[]> allParams = new List<int[]>();

            for (int i = 0; i < numberOfStreets; i++)
            {
                string[] currentParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] currentNumbers = new int[currentParams.Length];

                for (int j = 0; j < currentParams.Length; j++)
                {
                    currentNumbers[j] = int.Parse(currentParams[j]);
                }

                allParams.Add(currentNumbers);

                if (!nodes.ContainsKey(currentNumbers[0]))
                {
                    nodes.Add(currentNumbers[0], new Node(currentNumbers[0], int.MaxValue));
                }

                if (!nodes.ContainsKey(currentNumbers[1]))
                {
                    nodes.Add(currentNumbers[1], new Node(currentNumbers[1], int.MaxValue));
                }
            }

            for (int i = 0; i < allParams.Count; i++)
            {
                int[] currentParams = allParams[i];

                if (graph.ContainsKey(nodes[currentParams[0]]))
                {
                    graph[nodes[currentParams[0]]].Add(new Connection(nodes[currentParams[1]], currentParams[2]));
                }
                else
                {
                    graph.Add(nodes[currentParams[0]], new List<Connection>() { new Connection(nodes[currentParams[1]], currentParams[2]) });
                }

                if (graph.ContainsKey(nodes[currentParams[1]]))
                {
                    graph[nodes[currentParams[1]]].Add(new Connection(nodes[currentParams[0]], currentParams[2]));
                }
                else
                {
                    graph.Add(nodes[currentParams[1]], new List<Connection>() { new Connection(nodes[currentParams[0]], currentParams[2]) });
                }
            }

            double bestSum = double.MaxValue;

            for (int i = 0; i < hospitalNumbers.Length; i++)
            {
                DijkstraAlgorithm(nodes[hospitalNumbers[i]], graph);

                double sum = 0;

                foreach (var item in graph)
                {
                    if (!hospitalNumbers.Contains(item.Key.PointID))
                    {
                        sum += item.Key.DijktraDistance;
                    }
                }

                if (sum < bestSum)
                {
                    bestSum = sum;
                }
            }

            Console.WriteLine(bestSum);
        }

        /// <summary>
        /// Finds the shortest path in a graph using Sijkstra Algorithm
        /// </summary>
        /// <param name="source">The sourse node</param>
        /// <param name="graph">The graph model</param>
        public static void DijkstraAlgorithm(Node source, Dictionary<Node, List<Connection>> graph)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                if (source.PointID != node.Key.PointID)
                {
                    node.Key.DijktraDistance = int.MaxValue;
                    queue.Enqueue(node.Key);
                }
            }

            source.DijktraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijktraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    int potDistance = currentNode.DijktraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijktraDistance)
                    {
                        neighbour.Node.DijktraDistance = potDistance;
                        Node next = new Node(neighbour.Node.PointID, potDistance);
                        queue.Enqueue(next);
                    }
                }

                queue.Dequeue();
            }
        }
    }
}