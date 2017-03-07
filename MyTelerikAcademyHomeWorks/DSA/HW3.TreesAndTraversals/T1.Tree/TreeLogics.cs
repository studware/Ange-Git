using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace T1.Tree
{
    class TreeLogics
    {
        static void Main()
        {
            Dictionary<int, List<int>> nodes = ProcessInput();

            //1.Find the root
            int rootValue = FindRoot(nodes);

            TreeNode treeRoot = new TreeNode(rootValue);
            BuildTree(nodes, treeRoot);
            Console.WriteLine("Tree:\n{0}", treeRoot.ToString());
            int rootSum = treeRoot.SubTreeSum();

            //2.Find all leaf nodes
            List<TreeNode> leaves = new List<TreeNode>();
            FindLeafNodes(treeRoot, leaves);
            StringBuilder leafNodesPrint = new StringBuilder();
            foreach (TreeNode leafNode in leaves)
            {
                leafNodesPrint.Append(' '+leafNode.Value.ToString());
            }
            Console.WriteLine("All leaf nodes: {0}", leafNodesPrint);

            //3.Find all middle nodes
            List<TreeNode> middleNodes = new List<TreeNode>();
            FindMiddleNodes(treeRoot, middleNodes);
            StringBuilder middleNodesPrint = new StringBuilder();
            foreach (TreeNode middleNode in middleNodes)
            {
                middleNodesPrint.AppendLine(middleNode.Value.ToString());
            }
            string middleresult = middleNodesPrint.Length == 0 ? "No middle nodes" : middleNodesPrint.ToString();
            Console.WriteLine("All middle nodes:\n{0}", middleresult);

            //4.Find the longest path
            List<List<int>> treePaths = new List<List<int>>();
            List<int> currentTreePath = new List<int>();
            currentTreePath.Add(treeRoot.Value);
            DFSTraverse(treePaths, treeRoot, currentTreePath);
            string longestPath = GetLongestPath(treePaths);
            Console.WriteLine("\nThe longest path from the root is {0}", longestPath);

            //5.Find all paths in the tree with given sum S of their nodes
            int sum = 9;
            int currentSum = treeRoot.Value;
            treePaths = new List<List<int>>();
            currentTreePath = new List<int>();
            currentTreePath.Add(treeRoot.Value);
            DFSFindPathWithSum(treePaths, sum, currentSum, treeRoot, currentTreePath);
            string sumPaths = GetPaths(treePaths);
            Console.WriteLine("\nAll paths with sum={0} are:\n{1}", sum, sumPaths);

            //6.Find all subtrees with given sum S of their nodes
            List<TreeNode> subTrees = new List<TreeNode>();
            sum = 6;
            FindSubTrees(subTrees, sum, treeRoot);
            string subTreesPrint = ProcessSubTreesResult(subTrees);
            Console.WriteLine("All subtrees with sum={0} are:\n{1}", sum, subTreesPrint);
        }

        private static string ProcessSubTreesResult(List<TreeNode> subTrees)
        {
            if (subTrees.Count == 0)
            {
                return "No subtree available!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int counter = 1;
                foreach (TreeNode node in subTrees)
                {
                    sb.AppendLine("Subtree " + counter);
                    counter++;
                    sb.AppendLine(node.ToString());
                }
                return sb.ToString();
            }
        }

        private static void FindSubTrees(List<TreeNode> subTrees, int sum, TreeNode node)
        {
            int currentSubTreeSum = node.SubTreeSum();
            if (currentSubTreeSum == sum)
            {
                subTrees.Add(node);
            }

            foreach (TreeNode child in node.Children)
            {
                FindSubTrees(subTrees, sum, child);
            }
        }

        private static string GetPaths(List<List<int>> treePaths)
        {
            if (treePaths.Count == 0)
            {
                return "No paths found";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder result = new StringBuilder();
                foreach (List<int> path in treePaths)
                {
                    foreach (int item in path)
                    {
                        sb.Append(string.Format("{0} ", item));
                    }
                    result.AppendLine(sb.ToString());
                    sb.Clear();
                }

                return result.ToString();
            }
        }

        private static void DFSFindPathWithSum(List<List<int>> treePaths, int sum, int currentSum, TreeNode node, List<int> currentTreePath)
        {
            foreach (var child in node.Children)
            {
                currentTreePath.Add(child.Value);
                currentSum += child.Value;
                if (currentSum == sum)
                {
                    treePaths.Add(currentTreePath.GetRange(0, currentTreePath.Count));
                }
                DFSFindPathWithSum(treePaths, sum, currentSum, child, currentTreePath);
                currentTreePath.RemoveAt(currentTreePath.Count - 1);
                currentSum -= child.Value;
            }
        }

        private static string GetLongestPath(List<List<int>> treePaths)
        {
            int maxPathIndex = 0;
            int maxCount = 0;
            List<int> path;

            for (int i = 0; i < treePaths.Count; i++)
            {
                path = treePaths[i];
                if (path.Count > maxCount)
                {
                    maxCount = path.Count;
                    maxPathIndex = i;
                }
            }
            Console.WriteLine("Number of levels: {0}", maxCount);
            StringBuilder sb = new StringBuilder();
            path = treePaths[maxPathIndex];
            foreach (int item in path)
            {
                sb.AppendFormat("{0} ", item);
            }

            return sb.ToString();
        }

        private static void DFSTraverse(List<List<int>> treePaths, TreeNode node, List<int> currentTreePath)
        {
            if (node.Children.Count == 0)
            {
                treePaths.Add(currentTreePath.GetRange(0, currentTreePath.Count));
            }
            else
            {
                foreach (var child in node.Children)
                {
                    currentTreePath.Add(child.Value);
                    DFSTraverse(treePaths, child, currentTreePath);
                    currentTreePath.RemoveAt(currentTreePath.Count - 1);
                }
            }
        }

        private static void FindMiddleNodes(TreeNode node, List<TreeNode> middleNodes)
        {
            foreach (TreeNode child in node.Children)
            {
                if (child.Parent != null && child.Children.Count != 0)
                {
                    middleNodes.Add(child);
                }
                FindMiddleNodes(child, middleNodes);
            }
        }

        private static void FindLeafNodes(TreeNode node, List<TreeNode> leaves)
        {
            foreach (TreeNode childNode in node.Children)
            {
                if (childNode.Children.Count == 0)
                {
                    leaves.Add(childNode);
                }
                else
                {
                    FindLeafNodes(childNode, leaves);
                }
            }
        }

        private static void BuildTree(Dictionary<int, List<int>> nodes, TreeNode node)
        {
            int currentValue = node.Value;
            if (nodes.ContainsKey(currentValue))
            {
                foreach (int child in nodes[currentValue])
                {
                    TreeNode childNode = new TreeNode(child);
                    childNode.Parent = node;
                    node.Children.Add(childNode);
                    BuildTree(nodes, childNode);
                }
            }
        }

        private static int FindRoot(Dictionary<int, List<int>> nodes)
        {
            bool isChild = false;
            bool rootAvailable = false;
            int root = 0;

            foreach (KeyValuePair<int, List<int>> parentNode in nodes)
            {
                isChild = false;

                foreach (KeyValuePair<int, List<int>> itemNode in nodes)
                {
                    foreach (int child in itemNode.Value)
                    {
                        if (child == parentNode.Key)
                        {
                            isChild = true;
                        }
                    }
                }

                if (!isChild)
                {
                    root = parentNode.Key;
                    rootAvailable = true;
                    break;
                }
            }

            if (!rootAvailable)
            {
                throw new ArgumentException("No root available!");
            }

            return root;
        }

        private static Dictionary<int, List<int>> ProcessInput()
        {
            int N;
            Dictionary<int, List<int>> nodes = new Dictionary<int, List<int>>();
            using (StreamReader reader = new StreamReader("../../treeNodes.txt"))
            {
                if (!int.TryParse(reader.ReadLine(), out N))
                {
                    throw new ArgumentException("Invalid n!");
                }
                N--;

                int parent = 0;
                int child = 0;

                for (int i = 0; i < N; i++)
                {
                    string[] splits = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    parent = int.Parse(splits[0]);
                    child = int.Parse(splits[1]);

                    if (!nodes.ContainsKey(parent))
                    {
                        nodes.Add(parent, new List<int>());
                    }

                    nodes[parent].Add(child);
                }
            }

            return nodes;
        }
    }
}