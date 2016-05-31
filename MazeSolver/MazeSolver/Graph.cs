using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class Graph
    {

        public Node<string>[] GettingTheKeys(string[] lines)
        {
            Node<string>[] keys = new Node<string>[lines[0].Split(',').Length];

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
        public Dictionary<Node<string>, Node<string>[]> DictionarySetUp(string[] lines)
        {
            var keepTrack = new Dictionary<Node<string>, Node<string>[]>();

            for (int i = 2; i < lines.Length; i++)
            {
                //take a first letter because its the key, save the other letters
                int index = 0;
                string[] arrayElems = lines[i].Split(',').ToArray();
                var connections = new Node<string>[arrayElems.Length];

                for (int j = 1; j < arrayElems.Length; j++)
                {
                    Node<string> fillPosition = new Node<string>(arrayElems[j]);
                    connections[index] = fillPosition;
                    index++;
                }


                foreach (var connectedTo in connections)
                {
                    Console.WriteLine("connection: " + connectedTo);
                }

                keepTrack.Add(GettingTheKeys(lines)[i - 2], connections);

            }
            //add those letters to their matching key
            PrintKeepTrack(keepTrack);
            return keepTrack;
        }

        public void PrintKeepTrack(Dictionary<Node<string>, Node<string>[]> keyPair)
        {
            foreach (var pair in keyPair)
            {
                Console.WriteLine("Key: " + pair.Key + " Values:" + pair.Value);
            }
        }


        public class Node<T> where T : IComparable<T>
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
