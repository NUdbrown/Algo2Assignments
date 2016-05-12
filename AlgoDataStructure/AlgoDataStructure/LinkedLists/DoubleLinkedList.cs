using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        public int Count { get; protected set; }
        private Node<T> _headNode;
        private Node<T> _tailNode; 

        public DoubleLinkedList()
        {
            Initalize();
        } 
        private void Initalize()
        {
            Count = 0;
            _headNode = new Node<T>(default(T));
            _tailNode = new Node<T>(default(T));
        }

        public void Add(T value)
        {

            Node<T> temp = new Node<T>(value);
            Node<T> current = _headNode;

            while (current.GetIsNextNode() != null)
            {
                current = current.GetIsNextNode();
            }

            current.SetIsNextNode(temp);
            _tailNode = current.GetIsNextNode();
            _tailNode.SetIsPreviousNode(current);
            Count++;
        }

        public void Insert(T value, int index)
        {
            Node<T> temp = new Node<T>(value);

            if (index > 0 && index < Count)
            {             
                if (index < FindingTheMiddleIndex())
                {
                    Node<T> current = _headNode;
                
                    for (int i = 1; i < index && current.GetIsNextNode() != null; i++)
                    {
                        current = current.GetIsNextNode();
                    }

                    temp.SetIsNextNode(current.GetIsNextNode());
                    current.SetIsNextNode(temp);

                }
                else if (index >= FindingTheMiddleIndex())
                {
                    Node<T> current = _tailNode;
                    for (int i = Count; i > index && current.GetIsPreviousNode() != null; i--)
                    {
                        current = current.GetIsPreviousNode();
                    }

                   current.GetIsPreviousNode().SetIsNextNode(temp);
                    temp.SetIsNextNode(current);
                    current.SetIsPreviousNode(temp);

                }

                Count++;
            }
        }

        public T Get(int index)
        {
            if (index > 0 && index < Count)
            {
                if (index < FindingTheMiddleIndex())
                {
                    Node<T> current = _headNode;

                    for (int i = 1; i <= index; i++)
                    {
                        if (current.GetIsNextNode() != null)
                        {
                            current = current.GetIsNextNode();
                        }

                        return current.GetData();
                    }

                }
                else if(index >= FindingTheMiddleIndex())
                {
                    Node<T> current = _tailNode;

                    for (int i = Count; i > index; i--)
                    {
                        if (current.GetIsPreviousNode() != null)
                        {
                            current = current.GetIsPreviousNode();
                        }
                    }

                    return current.GetData();
                }
            }
            return default(T);

        }

        public T Remove()
        {

            Node<T> current = _headNode;

            _headNode = _headNode.GetIsNextNode();
            
            current.SetIsPreviousNode(null);

            Count--;


            return _headNode.GetData();
        }

        private int FindingTheMiddleIndex()
        {
            decimal findMiddle = Math.Round((decimal)(Count / 2));

            return Convert.ToInt32(findMiddle);
        }

        public T RemoveAt(int index)
        {
            T val = Get(index);
           

            if (index > 1 && index < Count)
            {
                if (index < FindingTheMiddleIndex())
                {

                    Node<T> current = _headNode;

                    for (int i = 1; i < index; i++)
                    {
                        if (current.GetIsNextNode() != null)
                        {
                            current = current.GetIsNextNode();
                        }

                    }
                    current.SetIsNextNode(current.GetIsNextNode().GetIsNextNode());
                }
                else if(index >= FindingTheMiddleIndex())
                {
                    Node<T> current = _tailNode;
                   
                    for (int i = Count; i > index; i--)
                    {
                        if (current.GetIsPreviousNode() != null)
                        {
                            current = current.GetIsPreviousNode();
                        }
                    }

                    current.GetIsPreviousNode().SetIsNextNode(current.GetIsNextNode());
                }             


            }

            Count--;

            return val;
        }

        public T RemoveLast()
        {

            Node<T> current = _headNode;
            Node<T> previous = _headNode.GetIsPreviousNode();

            T last = Get(Count);

            while (current.GetIsNextNode() != null)
            {
                previous = current;
                current = current.GetIsNextNode();
            }

            Node<T> result = _tailNode;
            _tailNode = previous;
            if (_tailNode == null)
                _headNode = null;
            else
                _tailNode.SetIsNextNode(null);
            Count--;

            return last;
        }

        public void Clear()
        {
            Initalize();
        }

        public int Search(T value)
        {

            Node<T> current = _headNode.GetIsNextNode();

            int index = -1;

            for (int i = 1; i < Count && current.GetIsNextNode() != null; i++)
            {
                if (current.GetData().Equals(value))
                {
                    return i;
                }

                current = current.GetIsNextNode();
            }

            return index;
        }
        
        public string ToString()
        {
            Node<T> current = _headNode.GetIsNextNode();
            string _out = "";

            while (current != null)
            {
                _out += "[" + current.GetData() + "]";
                current = current.GetIsNextNode();
            }

            return _out;
        }

        protected class Node<T> where T : IComparable<T>
        {
            private T _data;
            private Node<T> _isNextNode;
            private Node<T> _isPreviousNode; 

            public Node(T initalData)
            {
                _data = initalData;
                _isNextNode = null;
                _isPreviousNode = null;
            }

            public T GetData()
            {
                return _data;
            }

            public void SetData(T data)
            {
                _data = data;
            }

            public Node<T> GetIsNextNode()
            {
                return _isNextNode;
            }

            public void SetIsNextNode(Node<T> next)
            {
                _isNextNode = next;
            }

            public Node<T> GetIsPreviousNode()
            {
                return _isPreviousNode;
            }

            public void SetIsPreviousNode(Node<T> previous)
            {
                _isPreviousNode = previous;
            }
        }

    }

}
