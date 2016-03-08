using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructure
{
    public class Node<T> where T : IComparable<T>
    {
        /*have root, left and right nodes
         *be able to get those nodes and set them*/

        private T data;
        private Node<T> leftChild, rightChild;

        public Node(T data)
        {
            this.data = data;
            leftChild = null;
            rightChild = null;
        }

        public Node<T> LeftChild
        {
            get
            {
                return leftChild;
            }
            set
            {
                leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get
            {
                return rightChild;
            }

            set
            {
                rightChild = value;
            }

        }

        public T Data
        {
            get
            {
                return data;
            }

            set
            {
                value = data;
            }

        }

        public bool Contains(T value)
        {
            int result = value.CompareTo(data);
            if (result == 0)
            {
                return true;
            }
            if (result < 0 && LeftChild != null && LeftChild.Contains(value))
            {
                return true;
            }
            if (result > 0 && RightChild != null && RightChild.Contains(value))
            {
                return true;
            }
            return false;
        }

        public bool IsLeaf()
        {
            return (LeftChild == null && RightChild == null);
        }
    }
}
