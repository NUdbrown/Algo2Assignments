using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class Graph<T> where T : IComparable<T>
    {
        private Dictionary<string, Node<string>> _dictionary;

        public Dictionary<string, Node<string>> Dictionary
        {
            get
            {
                return _dictionary;
            }

            set
            {
                _dictionary = value;
            }
        }

        //create a dictionary, use lines in txt file to connect the nodes from the array to each other
        public Dictionary<string, Node<string>> DictionaryCreation(string [] lines)
        {
           _dictionary = new Dictionary<string, Node<string>> ();
            
            foreach (var value in lines[0].Split(','))
            {
                Node<string> temp = new Node<string>(value);
                _dictionary.Add(value, temp);
            }
            return _dictionary;
        }

        public void SetConnections(string [] lines)
        {
            _dictionary = DictionaryCreation(lines);
            foreach (var value in _dictionary.Values)
            {
                for (int i = 2; i < lines.Length; i++)
                {
                    if (lines[i].Split(',')[0].CompareTo(value.Data) == 0)
                    {
                        foreach (var conection in lines[i].Split(','))
                        {
                            value.ConnectedNodes.Add(_dictionary[conection]);
                            value.ConnectedNodes.Remove(value);
                        }                        
                    }
                }
            }

        }     

        public class Node<T> where T : IComparable<T>
        {

            private readonly T _data;
            public bool Visited { get; set; }
            public List<Node<T>> ConnectedNodes { get; set; }

            public Node(T data)
            {
                this._data = data;
                ConnectedNodes = new List<Node<T>>();

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
