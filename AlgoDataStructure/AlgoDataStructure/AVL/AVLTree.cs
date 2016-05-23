using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class AVLTree<T> where T: IComparable<T>
    {

        public int Count { get; protected set; }
        private Node<T> _root;

        public void Initializer()
        {
            Count = 0;
            _root = null;
        }

        //adds a new value to the tree, following the rules of a BST.
        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            bool notAdded = true;

            if (_root == null)
            {
                _root = newNode;
            }

            else
            {
                var current = _root;

                while (notAdded)
                {
                    if (value.CompareTo(current.Data) >= 0)
                    {
                        if (current.RightChild == null)
                        {
                            current.RightChild = newNode;
                            //_tree.Add(newNode.Data);
                            notAdded = false;
                        }
                        else
                        {
                            current = current.RightChild;
                        }
                    }
                    else if (value.CompareTo(current.Data) < 0)
                    {
                        if (current.LeftChild == null)
                        {
                            current.LeftChild = newNode;
                            notAdded = false;
                        }

                        else
                        {
                            current = current.LeftChild;
                        }
                    }
                }
            }
            Count++;

        }

        //returns true if the specified value is in the tree.
        public bool Contains(T value)
        {

            if (_root == null)
            {
                return false;
            }

            return _root.Contains(value);

        }

        public bool Remove(T value)
        {
            //no children
            //one child - right or left
            //both children
            bool removed = false;
            Node<T> current = _root;
            Node<T>[] valuesNodeDetails = FindNodeToRemove(value);
            Node<T> parent = valuesNodeDetails[1];
            Node<T> foundNode = valuesNodeDetails[0];

            //no children
            if (foundNode.LeftChild == null && foundNode.RightChild == null)
            {
                if (foundNode.Data.CompareTo(parent.Data) < 0)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }

                Count--;
                removed = true;
            }

            //one child, left or right
            if (foundNode.LeftChild != null && foundNode.RightChild == null)
            {
                if (parent == null)
                {
                    _root = foundNode.LeftChild;
                }
                else
                {
                    if (foundNode.Data.CompareTo(parent.Data) < 0)
                    {
                        parent.LeftChild = foundNode.LeftChild;
                    }
                    else
                    {
                        parent.RightChild = foundNode.LeftChild;
                    }

                }
                Count--;
                removed = true;
            }
            else if (foundNode.RightChild != null && foundNode.LeftChild == null)
            {
                if (parent == null)
                {
                    _root = foundNode.RightChild;
                }
                else
                {
                    if (foundNode.Data.CompareTo(parent.Data) < 0)
                    {
                        parent.LeftChild = foundNode.RightChild;
                    }
                    else
                    {
                        parent.RightChild = foundNode.RightChild;
                    }
                }

                Count--;
                removed = true;
            }
            else //both children
            {
                Node<T>[] lastNodeDetails = FindLastLeftNode(foundNode);
                Node<T> lastLeft = lastNodeDetails[1];
                Node<T> parentOfLastLeft = lastNodeDetails[0];

                if (parent == null)
                {
                    _root = lastLeft;
                    lastLeft.LeftChild = _root.LeftChild;
                    lastLeft.RightChild = _root.RightChild;
                    parentOfLastLeft.LeftChild = null;
                }
                else
                {
                    if (foundNode.Data.CompareTo(parent.Data) < 0)
                    {
                        parent.LeftChild = lastLeft;
                    }
                    else
                    {
                        parent.RightChild = lastLeft;
                    }

                    lastLeft.LeftChild = foundNode.LeftChild;
                    lastLeft.RightChild = foundNode.RightChild;
                    parentOfLastLeft.LeftChild = null;

                }

                Count--;
                removed = true;
            }

            return removed;
        }

        private Node<T>[] FindNodeToRemove(T value)
        {
            Node<T> current = _root;
            bool notFound = true;
            Node<T> parent = null;
            Node<T>[] nodeDetails = new Node<T>[2];

            while (notFound)
            {
                if (current != null)
                {
                    if (value.CompareTo(current.Data) < 0)
                    {
                        parent = current;
                        current = current.LeftChild;

                    }
                    else if (value.CompareTo(current.Data) >= 0)
                    {
                        parent = current;
                        current = current.RightChild;
                    }
                    else
                    {
                        notFound = false;
                    }
                }
                else
                {
                    notFound = false;
                    break;
                }


            }

            nodeDetails[0] = current;
            nodeDetails[1] = parent;

            return nodeDetails;
        }

        private static Node<T>[] FindLastLeftNode(Node<T> start)
        {
            Node<T> parent = null;
            Node<T> currentNode = start;

            Node<T>[] pair = new Node<T>[2];

            if (currentNode.RightChild != null)
            {
                currentNode = currentNode.RightChild;
                while (currentNode != null)
                {
                    if (currentNode.LeftChild != null)
                    {
                        parent = currentNode;
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        break;
                    }
                }


                pair[0] = parent;
                pair[1] = currentNode;
            }

            return pair;
        }

        //removes all values from the tree
        public void Clear()
        {
            Initializer();
        }



        protected class Node<T> where T : IComparable<T>
        {
            /*have root, left and right nodes
             *be able to get those nodes and set them*/

            private readonly T _data;
            private int _balance;

            public Node(T data)
            {
                this._data = data;
                LeftChild = null;
                RightChild = null;
                Parent = null;
            }

            public Node(T data, int balance)
            {
                this._data = data;
                this._balance = balance;
            }

            public Node<T> LeftChild { get; set; }

            public Node<T> RightChild { get; set; }

            public Node<T> Parent { get; set; }

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

            public bool Contains(T value)
            {
                int result = value.CompareTo(_data);
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

        }
    }
}
