using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructure
{
    public class DoubleLinkedList<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _headNode;

        public DoubleLinkedList()
        {
            Initalize();
        } 
        private void Initalize()
        {
            _count = 0;
            _headNode = new Node<T>(default(T));
        }

        public void Add(T value)
        {

        }

        public void Insert(T value, int index)
        {

        }

        public int Count()
        {
            return _count;
        }

        public T Get(int index)
        {
            return default(T);
        }

        public T Remove()
        {
            return default(T);
        }

        public T RemoveAt()
        {
            return default(T);
        }

        public T RemoveLast()
        {
            return default(T);
        }

        public void Clear()
        {
            Initalize();
        }

        public int Search(T value)
        {
            return 0;
        }
        
        public string ToString()
        {
            return null;
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
