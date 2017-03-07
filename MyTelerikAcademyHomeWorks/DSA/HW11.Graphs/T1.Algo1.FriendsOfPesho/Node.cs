using System;
using System.Collections.Generic;
using System.Linq;

namespace T1.Algo1.FriendsOfPesho
{
    public class Node : IComparable<Node>
    {
        public Node(int houseNumber, int dijktraDistance)
        {
            this.PointID = houseNumber;
            this.DijktraDistance = dijktraDistance;
        }

        public int PointID { get; set; }

        public int DijktraDistance { get; set; }

        public override int GetHashCode()
        {
            return this.PointID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return this.PointID.Equals(other.PointID);
        }

        public int CompareTo(Node other)
        {
            return this.DijktraDistance.CompareTo(other.DijktraDistance);
        }
    }
}
