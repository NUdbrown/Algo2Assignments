using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Node<T> where T : IComparable<T>
    {
        public T SocketId { get; set; }
        public List<Edge> ConnectedSockets { get; set; }
        public bool Visited { get; set; }

        public Node(T socketId)
        {
            SocketId = socketId;
            ConnectedSockets = new List<Edge>();

        }

    }
}
