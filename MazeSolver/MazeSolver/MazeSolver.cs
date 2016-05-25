using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class MazeSolver
    {

        public static void Main(string[] args)
        {
            //read in the file from args

            Console.WriteLine("Please type in the location of a file that has the adjacency list of an undirected graph: ");
            string filePath = Console.ReadLine();

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {

                var list = new List<string>();
                while (!streamReader.EndOfStream)
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
                        //SolveMaze(lines);
                        list = new List<string>();
                        DictionarySetUp(lines);
                    }

                }
            }

        }

        public static string SolveMaze(string[] lines)
        {
            var keepTrack = DictionarySetUp(lines);
            string[] beginend = lines[0].Split(',');
            var start = beginend.ElementAt(0);
            var end = beginend.ElementAt(1);

            /**
            //Implements a breadth-ﬁrst search traversal of a given graph 
            //Input: Graph G=V,E 
            //Output: Graph G with its vertices marked with consecutive integers 
            // in the order they are visited by the BFS traversal mark each vertex in V with 0 as a mark of being “unvisited” 
            count ←0 
            for each vertex v in V 
                do if v is marked with 0 
                bfs(v)
            bsf(v)
            //visits all the unvisited vertices connected to vertex v 
            //by a path and numbers them in the order they are visited 
            //via global variable count count ←count +1;
            mark v with count and initialize a queue with v
            while the queue is not empty 
                do for each vertex w in V adjacent to the front vertex 
                    do if w is marked with 0 
                    count ←count +1; 
                mark w with count add w to the queue remove the front vertex from the queue
            */

            return null;
        }

        private static string PrintOut(List<string> outputs)
        {
            return outputs.Aggregate("", (current, item) => current + item);
        }

        //getting the keys
        private static Node<string> [] GettingTheKeys(string[] lines)
        {
            Node<string>[] keys = new Node<string>[] {};

            int index = 0;
            foreach (var key in lines[0].Split(','))
            {
                Node<string> temp = new Node<string>(key);
                keys[index] = temp;
                index++;
            }

            return keys;
        } 

        //separates the connections(values to keys)
        private static Dictionary<Node<string>, Node<string>[]> DictionarySetUp(string[] lines)
        {
            var keepTrack = new Dictionary<Node<string>, Node<string>[]>();
            int index = 1;
            Node<string> [] connections = new Node<string>[] {};

            for (var i = 2; i < lines.Length; i++)
            {
                //take a first letter because its the key, save the other letters
                foreach (var link in lines[i].Split(','))
                {
                    connections[index] = new Node<string>(link);
                    index++;
                }
                
                
                foreach (var connectedTo in connections)
                {
                    Console.WriteLine("connection: " + connectedTo);
                }

                keepTrack.Add(GettingTheKeys(lines)[i - 2], connections);

                //for (int j = 0; i < keepTrack.Count; i++)
                //{
                //    Console.WriteLine("Key: " + keepTrack.Keys.ElementAt(j));
                //    for (int k = 0; k < keepTrack.Values.Count; k++)
                //    {
                //        Console.WriteLine("\tConnections: " + keepTrack.Values.ElementAt(k));
                //    }
                //}

                


            }
            //add those letters to their matching key
            PrintKeepTrack(keepTrack);
            return keepTrack;
        }

        private static void PrintKeepTrack(Dictionary<Node<string>, Node<string>[]> keyPair)
        {
            foreach (var pair in keyPair)
            {
                Console.WriteLine("Key: " + pair.Key + " Values:" + pair.Value);
            }
        }

        protected class Node<T> where T : IComparable<T>
        {

            private readonly T _data;
            public int Visited { get; set; }

            public Node(T data)
            {
                this._data = data;

            }

            public T Data
            {
                get
                {
                    return _data;
                }

                set
                {
                    value = _data;
                }

            }

        }
    }
}
