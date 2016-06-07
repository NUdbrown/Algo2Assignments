using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class MSTEdge
    {
        public Node<string> StartingEdgeNode { get; set; }
        public Edge ConnectedEdge { get; set; }

        public MSTEdge(Node<string> startingEdgeNode, Edge connectionEdge)
        {
            StartingEdgeNode = startingEdgeNode;
            ConnectedEdge = connectionEdge;
        }
    }
}
