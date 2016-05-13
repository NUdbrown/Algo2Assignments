using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _root;
        //private readonly List<T> _tree = new List<T>();

        public void Initializer()
        {
            _count = 0;
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
                            //////_tree.Add(newNode.Data);
                            notAdded = false;
                        }

                        else
                        {
                            current = current.LeftChild;
                        }
                    }
                }
            }
            _count++;

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

        /*removes the specified value from the tree if it is present, or does nothing if the value is not present.
        If the value appears more than once, only the first occurrence of the value is removed.
        The one closests to the root. The next inorder value should take the place of the removed value.*/
        public bool Remove(T value)
        {
           //no children
           //one child - right or left
           //both children
            bool removed = false;
            Node<T> current = _root;
            Node<T>[] valuesNodeDetails = FindNodeToRemove(value);
            Node<T> parent = valuesNodeDetails[3];
            Node<T> foundNode = valuesNodeDetails[0];

            //check to see where to travel to look for the node
            //once you find the node, find the node it will be replaced with

            //no children
            if (valuesNodeDetails[1] == null && valuesNodeDetails[2] == null)
            {
                if (foundNode.Data.CompareTo(parent.Data) > 0)
                {
                    parent.RightChild = null;
                }
                else
                {
                    parent.LeftChild = null;
                }

                _count--;
                removed = true;
            }

            //one child, left or right
            if (valuesNodeDetails[1] != null && valuesNodeDetails[2] == null || valuesNodeDetails[2] != null && valuesNodeDetails[1] == null)
            {
                foundNode = foundNode.LeftChild;
                if (parent.Data.CompareTo(foundNode.Data) >= 0)
                {
                    parent.RightChild = foundNode;
                }
                else
                {
                    parent.LeftChild = foundNode;
                }


            }
            else if(valuesNodeDetails[2] != null)
            {
                Node<T> temp = foundNode;
                foundNode = foundNode.RightChild;
                temp = null;
            }
            //both children

  

            return removed;
        }

        private Node<T> [] FindNodeToRemove(T value)
        {
            Node<T> current = _root;
            bool notFound = true;
            Node<T> left = null, right = null, parent = null;
            Node<T> [] nodeDetails = new Node<T> [4];

            while (notFound)
            {
                if (current != null)
                {
                    if (value.CompareTo(current.Data) < 0)
                    {
                        parent = current;
                        current = current.LeftChild;

                    }
                    else if (value.CompareTo(current.Data) > 0)
                    {
                        parent = current;
                        current = current.RightChild;
                    }
                    else
                    {
                        left = current.LeftChild;
                        right = current.RightChild;
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
            nodeDetails[1] = left;
            nodeDetails[2] = right;
            nodeDetails[3] = parent;

            return nodeDetails;
        }

        private static Node<T>[] FindLastLeftNode(Node<T> start)
        {
            Node<T> candidate = null;
            Node<T> parent = null;
            Node<T> node = start;

            Node<T>[] pair = new Node<T>[2];

            if (node.RightChild != null)
            {
                node = node.RightChild;
                while (node != null)
                {
                    if (node.LeftChild != null)
                    {
                        parent = node;
                        node = node.LeftChild;
                    }
                    else
                    {
                        parent = start;
                        break;
                    }
                }

                candidate = node;

                pair[0] = parent;
                pair[1] = candidate;
            }
            else
            {
                candidate = node.LeftChild;
                pair[0] = node;
                pair[1] = candidate;
            }


            return pair;
        }

 
        //private int WhereInTheTree(T value)
        //{
        //    int returnThis = 0;
        //    for (int i = 0; i <= Count(); i++)
        //    {
        //        if (_tree[i].Equals(value))
        //        {
        //            returnThis = i;
        //            break;
        //        }
        //    }

        //    return returnThis;
        //}


        //removes all values from the tree
        public void Clear()
        {
            Initializer();
        }

        //returns the number of values in the tree
        public int Count()
        {
            return _count;
        }

        //------------------------------------------------------------------------------------------------
        //All of the “order” functions above return a string in the format of “v1, v2, …, vn”.
        //returns an in-order string representation of all the values in the BST [Left, Parent, then Right]
        public string Inorder()
        {

            string output = "";

            if (_root == null)
            {
                return output;
            }

            output = InorderTraversal(_root);

            return output.Remove(output.Length - 2);

        }


        private string InorderTraversal(Node<T> node)
        {
            string returnThis = "";


            if (node.LeftChild != null)
            {
                returnThis += InorderTraversal(node.LeftChild);
            }

            returnThis += node.Data + ", ";

            if (node.RightChild != null)
            {
                returnThis += InorderTraversal(node.RightChild);
            }

            return returnThis;

        }


        //returns a pre-order string representation of all the values in the BST [Parent, Left, then Right]
        public string Preorder()
        {
            string output = "";

            if (_root == null)
            {
                return output;
            }
            output = PreTraversal(_root);

            return output.Remove(output.Length - 2);
        }

        private string PreTraversal(Node<T> node)
        {
            string returnThis = "";


            returnThis += node.Data + ", ";

            if (node.LeftChild != null)
            {
                returnThis += PreTraversal(node.LeftChild);
            }


            if (node.RightChild != null)
            {
                returnThis += PreTraversal(node.RightChild);
            }


            return returnThis;

        }

        //returns a post-order string representation of all the values in the BST [Left, Right, then Parent]
        public string Postorder()
        {
            string output = "";

            if (_root == null)
            {
                return output = "";
            }

            output = PostTraversal(_root);

            return output.Remove(output.Length - 2);
        }

        private string PostTraversal(Node<T> node)
        {
            string returnThis = "";

            if (_root == null)
            {
                returnThis = "";
            }

            if (node.LeftChild != null)
            {
                returnThis += PostTraversal(node.LeftChild);
            }

            if (node.RightChild != null)
            {
                returnThis += PostTraversal(node.RightChild);
            }

            returnThis += node.Data + ", ";

            return returnThis;

        }

        //---------------------------------------------------------------------------------------------------



        //returns the height of the BST, where the empty tree is 0 and the simple tree is 1.
        public int Height()
        {
            return HeightHelper(_root);
        }

        private int HeightHelper(Node<T> r)
        {
            int height = 0;

            if (r == null)
            {
                height = 0;
            }
            else
            {

                var leftside = HeightHelper(r.LeftChild);

                var rightside = HeightHelper(r.RightChild);

                height = Math.Max(leftside, rightside) + 1;

            }

            return height;
        }

        //returns an Array representation of the values in the BST using in-order traversal.
        public T [] ToArray()
        {
            //T [] represent = new T[_count + 1];
            string theNodes = InorderTraversal(_root);

            Type elementType = typeof(T);

            string[] entries = theNodes.Split(',');
            
            System.Array array = Array.CreateInstance(elementType, Count());

            for (int i = 0; i < Count(); i++)
            {
                array.SetValue(Convert.ChangeType(entries[i], elementType), i);
            }

            return (T[]) array;

           // return represent;
        }

        //private T InorderTraversalForArray(Node<T> node)
        //{
        //    T addThis;
        //    if (node.LeftChild != null)
        //    {

        //        addThis = InorderTraversalForArray(node.LeftChild);
        //    }


        //    if (node.RightChild != null)
        //    {
        //       addThis =  InorderTraversalForArray(node.RightChild);               
        //    }

        //    return addThis;

        //}

        public class AVLTree
        {

        }

        protected class Node<T> where T : IComparable<T>
        {
            /*have root, left and right nodes
             *be able to get those nodes and set them*/

            private T _data;
            private Node<T> _leftChild, _rightChild;
            private int _balance;

            public Node(T data)
            {
                this._data = data;
                _leftChild = null;
                _rightChild = null;
            }

            public Node(T data, int balance)
            {
                this._data = data;
                this._balance = balance;
            }

            public Node<T> LeftChild
            {
                get
                {
                    return _leftChild;
                }
                set
                {
                    _leftChild = value;
                }
            }

            public Node<T> RightChild
            {
                get
                {
                    return _rightChild;
                }

                set
                {
                    _rightChild = value;
                }

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

            public bool IsLeaf()
            {
                return (LeftChild == null && RightChild == null);
            }
        }
    }
}
