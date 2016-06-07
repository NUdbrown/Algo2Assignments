using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Network
    {
        private readonly Architecture _architecture = new Architecture();

        public static void Main(string[] args)
        {
            Network network = new Network();
            network.Run();
        }

        public void Run()
        {
            Console.WriteLine("Please type in the location of the text file containing the network socketId: ");
            string filePath = Console.ReadLine();

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                var list = new List<string>();
                while (fileStream.CanRead)
                {
                    var line = "";
                    line = streamReader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        list.Add(line);
                    }
                    else
                    {
                        var lines = list.ToArray();

                        //solving methods called here
                        _architecture.SetUpNetworking(lines);
                        PrintFinalMSTs();
                        list.Clear();
                        if (streamReader.EndOfStream)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }

        }

        public List<List<MSTEdge>> FindMinSpanningTrees()
        {
            //list of nodes
            var nodes = _architecture.Dictionary;
            //create new list of candidates
            List<MSTEdge> candidateEdges = new List<MSTEdge>();
            //list of MSTs
            List<List<MSTEdge>> collectionOfMSTs = new List<List<MSTEdge>>();

            while (nodes.Values.Where(v => v.Visited != true).Count() > 0)
            {
                //create new mst
                List<MSTEdge> mst = new List<MSTEdge>();

                //start at first unvisited node
                var current = nodes.Values.First(v => v.Visited != true);

                do
                {
                    current.Visited = true;

                    //purge mstEdges that have already been visited
                    for (int i = 0; i < candidateEdges.Count; i++)
                    {
                        if (candidateEdges[i].ConnectedEdge.Socket.Visited == true)
                        {
                            candidateEdges.Remove(candidateEdges[i]);
                        }
                    }

                    //Load its "unvisited" edges into the edges collection
                    candidateEdges.AddRange(from edge in current.ConnectedSockets
                                            where edge.Socket.Visited != true
                                            select new MSTEdge(current, edge));

                    if (candidateEdges.Count > 0)
                    {
                        //Find min distance of edges
                        int min = candidateEdges.Select(m => m.ConnectedEdge.Distance).Min();
                        //select the minimum edge
                        var smallestEdge = candidateEdges.FirstOrDefault(e => e.ConnectedEdge.Distance == min);
                        //Add it to mst
                        mst.Add(smallestEdge);
                        //Update current to the selected edge desitnation
                        current = nodes[smallestEdge.ConnectedEdge.Socket.SocketId];
                    }

                } while (!current.Visited);

                //Add mst to the msts collection
                collectionOfMSTs.Add(mst);
            }

            return collectionOfMSTs;
        }

        public void PrintFinalMSTs()
        {
            List<List<MSTEdge>> listOfMSTs = FindMinSpanningTrees();
            int mstCableTotal = 0;
            int overallTotal = 0;

            for (int i = 0; i < listOfMSTs.Count; i++)
            {
                Console.WriteLine("___MST " + i + "___");
                var mst = listOfMSTs[i];
                for (int j = 0; j < mst.Count; j++)
                {
                    Console.WriteLine(mst[j].StartingEdgeNode.SocketId + ":" + mst[j].ConnectedEdge.Socket.SocketId);
                    mstCableTotal = (mstCableTotal + mst[j].ConnectedEdge.Distance);

                }
                Console.WriteLine("CABLE AMOUNT REQUIRED FOR MST: " + mstCableTotal);
                overallTotal = (overallTotal + mstCableTotal);
            }

            Console.WriteLine("CABLE AMOUNT REQUIRED FOR ENTIRE NETWORK: " + overallTotal);

        }

    }
}
