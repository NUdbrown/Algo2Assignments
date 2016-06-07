using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Edge
    {
        private Node<string> node;

        public int Distance { get; set; }
        public Node<string> Socket { get; set; }

        public Edge(Node<string> socket, int distance)
        {
            this.Socket = socket;
            this.Distance = distance;
        }
    }
}
