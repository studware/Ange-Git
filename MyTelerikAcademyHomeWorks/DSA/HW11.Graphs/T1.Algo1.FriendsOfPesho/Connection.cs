using System;
using System.Collections.Generic;
using System.Linq;

namespace T1.Algo1.FriendsOfPesho
{
    public class Connection
    {
        public Connection(Node node, int distance)
        {
            this.Node = node;
            this.Distance = distance;
        }

        public Node Node { get; set; }

        public int Distance { get; set; }
    }
}
