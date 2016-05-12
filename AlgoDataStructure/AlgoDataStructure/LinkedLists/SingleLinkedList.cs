using System;
using System.Runtime.InteropServices;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {

        public int _count { get; protected set; }
        private Node<T> _headNode;
        private Node<T> _tail; 

        public SingleLinkedList()
        {
            Initialize();
        }
     
        private void Initialize()
        {
            _count = 0;
            _headNode = new Node<T>(default(T));
            _tail = new Node<T>(default(T));
            
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
            _tail = current.GetIsNextNode();
            _count++;
        }

        public void Insert(T value, int index)
        {
            Node<T> temp = new Node<T>(value);
            Node<T> current = _headNode;

            for (int i = 1; i < index && current.GetIsNextNode() != null; i++)
            {
                current = current.GetIsNextNode();
            }

            temp.SetIsNextNode(current.GetIsNextNode());
            current.SetIsNextNode(temp);
            _count++;
        }


        public T Get(int index)
        {
            if (index <= 0)
                return default(T);

            Node<T> current = _headNode.GetIsNextNode();
            for (int i = 1; i < index; i++)
            {
                if (current.GetIsNextNode() == null)
                    return default(T);

                current = current.GetIsNextNode();
            }
            return current.GetData();
        }

        public T Remove()
        {
            Node<T> current = _headNode;

            _headNode = current.GetIsNextNode();

            current.SetIsNextNode(current.GetIsNextNode().GetIsNextNode());
            _count--;


            return _headNode.GetData();
        }

        public T RemoveAt(int index)
        {
            T val = Get(index);

            if (index > 1 && index < _count)
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

            _count--;

            return val;
        }

        public T RemoveLast()
        {
            Node<T> current = _headNode;
            Node<T> previous = null;

            T last = Get(_count);


            while (current.GetIsNextNode() != null)
            {
                previous = current;
                current = current.GetIsNextNode();
            }

            Node<T> result = _tail;
            _tail = previous;
            if (_tail == null)
                _headNode = null;
            else
                _tail.SetIsNextNode(null);
            _count--;


            return last;
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

        //removes all values in the list
        public void Clear()
        {
            Initialize();

        }

       public int Search(T value)
        {

            Node<T> current = _headNode.GetIsNextNode();

            int index = -1;
            
            for (int i = 1; i < _count && current.GetIsNextNode() != null; i++)
            {
                if (current.GetData().Equals(value))
                {
                    return i;
                }

                current = current.GetIsNextNode();
            }

            return index;

        }

        protected class Node<T> where T : IComparable<T>
        {
            private T _data;
            private Node<T> _isNextNode;
        
            public Node(T initalData)
            {
                _data = initalData;
                _isNextNode = null;
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



        }
    }
}
