using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Architecture
    {
        public Dictionary<string, Node<string>> Dictionary { get; set; }

        public void GatheringAllSockets(string[] lines)
        {
            Dictionary = new Dictionary<string, Node<string>>();

            foreach (var socketId in lines[0].Split(','))
            {
                Node<string> id = new Node<string>(socketId);
                Dictionary.Add(socketId, id);
            }
        }

        public void SetUpNetworking(string[] lines)
        {
            GatheringAllSockets(lines);
           
            for (int index = 1; index < lines.Length; index++)
            {
                var connections = lines[index].Split(',');
                var value = Dictionary[connections[0]];
                for (int j = 1; j < connections.Length; j++)
                {
                    var splitInfo = connections[j].Split(':');
                    int distance = Int32.Parse(splitInfo[1]);
                    value.ConnectedSockets.Add(new Edge(Dictionary[splitInfo[0]], distance));
                }

                //Console.WriteLine("Socket: " + value.SocketId);
                //foreach (var connect in value.ConnectedSockets)
                //{
                //    Console.WriteLine("connected to: " + connect.Socket.SocketId + ":" + connect.Distance);
                //}
                //Console.WriteLine();
            }

        }
    }


   
}

