using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T1.Tree
{
    public class TreeNode
    {
        private int value;
        private TreeNode parent;
        private List<TreeNode> children;

        public TreeNode(int value)
        {
            this.value = value;
            this.parent = null;
            this.children = new List<TreeNode>();
        }

        public TreeNode Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public List<TreeNode> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            DFSToString(result, 1, this);

            return result.ToString();
        }

        private void DFSToString(StringBuilder sb, int counter, TreeNode currentNode)
        {
            int currentValue = currentNode.Value;
            string format = new string(' ', 3*counter);
            sb.AppendLine(format + currentValue);
            int currentLevel = counter;

            if (currentNode.Children.Count > 0)
            {
                currentLevel++;
                foreach (TreeNode child in currentNode.Children)
                {
                    DFSToString(sb, currentLevel, child);
                }
            }
        }

        public int SubTreeSum()
        {
            int sum = 0;
            sum = SumDFS(sum, this);

            return sum;
        }

        private int SumDFS(int sum, TreeNode treeNode)
        {
            sum += treeNode.Value;
            foreach (TreeNode child in treeNode.Children)
            {
                sum = SumDFS(sum, child);
            }

            return sum;
        }
    }
}