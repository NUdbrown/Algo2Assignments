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

            if (_headNode.GetData().Equals(default(T)))
            {
                current.SetData(value);
            }
            else
            {
                while (current.GetIsNextNode() != null)
                {
                    current = current.GetIsNextNode();
                }
                current.SetIsNextNode(temp);
                _tailNode = current.GetIsNextNode();
                _tailNode.SetIsPreviousNode(current);
            }
            Count++;
        }

        //fix insert at beginning and end
        public void Insert(T value, int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            Node<T> temp = new Node<T>(value);
            Node<T> current = _headNode;

            if (index < FindingTheMiddleIndex())
            {

                for (int i = 0; i < index && current.GetIsNextNode() != null; i++)
                {
                    current = current.GetIsNextNode();
                }

                if (current == _headNode)
                {
                    _headNode = temp;
                    _headNode.SetIsNextNode(current);
                    current.SetIsPreviousNode(_headNode);
                    _headNode.SetIsPreviousNode(null);
                }
                else
                {
                    current.GetIsPreviousNode().SetIsNextNode(temp);
                    temp.SetIsNextNode(current);    
                }

            }
            else
            {
                current = _tailNode;

                for (int i = Count - 1; i > index; i--)
                {
                    current = current.GetIsPreviousNode();
                }

                current.GetIsPreviousNode().SetIsNextNode(temp);
                temp.SetIsNextNode(current);
                temp.SetIsPreviousNode(current.GetIsPreviousNode());
                current.SetIsPreviousNode(temp);
            }

            Count++;
        }

        public T Get(int index)
        {
            T result = default(T);
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();

            Node<T> current = _headNode;

            if (index < FindingTheMiddleIndex())
            {

                for (int i = 0; i < index; i++)
                {
                    current = current.GetIsNextNode();
                }

            }
            else
            {
                current = _tailNode;

                for (int i = Count - 1; i > index; i--)
                {
                    current = current.GetIsPreviousNode();
                }

            }

            result = current.GetData();

            return result;
        }

        public T Remove()
        {

            Node<T> current = _headNode;
            Node<T> temp = _headNode;
            _headNode = _headNode.GetIsNextNode();
            current.SetIsPreviousNode(null);

            Count--;


            return temp.GetData();
        }

        private int FindingTheMiddleIndex()
        {
            decimal findMiddle = Math.Round((decimal)(Count / 2));

            return Convert.ToInt32(findMiddle);
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            T val = Get(index);

            Node<T> current = _headNode;

            if (index < FindingTheMiddleIndex())
            {


                for (int i = 0; i < index; i++)
                {
                    current = current.GetIsNextNode();

                }

                if (current == _headNode)
                {
                    _headNode = current.GetIsNextNode();
                    _headNode.SetIsPreviousNode(null);
                }
                else
                {
                    current.GetIsPreviousNode().SetIsNextNode(current.GetIsNextNode());
                }


            }
            else
            {
                current = _tailNode;

                for (int i = Count - 1; i > index; i--)
                {
                    current = current.GetIsPreviousNode();
                }

                if (current == _tailNode)
                {
                    _tailNode = _tailNode.GetIsPreviousNode();
                    _tailNode.SetIsNextNode(null);
                }
                else
                {
                    Node<T> temp = current.GetIsNextNode();
                    current.GetIsPreviousNode().SetIsNextNode(temp);
                    temp.SetIsPreviousNode(temp.GetIsPreviousNode());
                    
                }
                


            }


            Count--;

            return val;
        }

        public T RemoveLast()
        {

            Node<T> current = _headNode;
            Node<T> previous = _headNode.GetIsPreviousNode();

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

            return result.GetData();
        }

        public void Clear()
        {
            Initalize();
        }

        public int Search(T value)
        {

            Node<T> current = _headNode;

            int index = -1;

            for (int i = 0; i < Count; i++)
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
            Node<T> current = _headNode;
            string _out = "";

            if (Count == 0)
            {
                return _out;
            }

            while (current != null)
            {
                _out += current.GetData() + ", ";
                current = current.GetIsNextNode();
            }


            return _out.Remove(_out.Length - 2);
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
