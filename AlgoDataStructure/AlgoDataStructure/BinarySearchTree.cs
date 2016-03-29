using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _root;
        private readonly List<T> _tree = new List<T>();

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
                _tree.Add(_root.Data);
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
                            _tree.Add(newNode.Data);
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
                            _tree.Add(newNode.Data);
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

        //private void ReOrderTreeAtRoot(int loc)
        //{
        //    T temp = _tree[loc];
        //    _tree[0] = temp;
        //    _tree.RemoveAt(loc);            
        //}

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
            //Node<T> target = null;

            Node<T> parent = null;

            Node<T> current = _root;

            if (Contains(value))
            {
                if (value.CompareTo(current.Data) == 0)
                {
                    Node<T>[] temp = FindLastLeftNode(current);

                    if (temp[1].RightChild != null)
                    {
                        temp[0].LeftChild = temp[1].RightChild;
                    }

                    Node<T> oldRootsLeftChild = _root.LeftChild;
                    current = temp[1];
                    current.RightChild = temp[0];
                    current.LeftChild = oldRootsLeftChild;
                    _root = current;

                }
                else
                {
                    Node<T> temp = current;

                    while (!temp.Data.Equals(value))
                    {
                        parent = temp;

                        if (temp.Data.CompareTo(value) < 0)
                        {
                            temp = temp.RightChild;
                            if (temp.Data.Equals(value))
                            {
                                break;
                            }
                        }
                        else if (temp.Data.CompareTo(value) > 0)
                        {
                            temp = temp.LeftChild;
                            if (temp.Data.Equals(value))
                            {
                                break;
                            }
                        }
                    }

                    Node<T>[] pairs = FindLastLeftNode(temp);

                    if (pairs[1] == null && pairs[0] == null) //no kids
                    {
                        if (parent.RightChild.Data.Equals(value))
                        {
                            parent.RightChild = null;
                        }
                        else
                        {
                            parent.LeftChild = null;
                        }
                    }
                    else if (pairs[1] != null)
                    {
                        if (temp.LeftChild != null && temp.RightChild != null || temp.LeftChild == null && temp.RightChild != null)
                        {
                            Node<T> oldRootsLeftChild = temp.LeftChild;
                            temp = temp.RightChild;
                            temp.LeftChild = oldRootsLeftChild;
                            parent.LeftChild = temp;
                        }
                        else if (temp.LeftChild != null && temp.RightChild == null)
                        {
                            Node<T> oldRootsLeftChild = temp.LeftChild;
                            temp = temp.LeftChild;
                            parent.RightChild = temp;
                        }
                       
                    }
                    else if (pairs[1] == null)
                    {
                        if (temp.LeftChild == null && temp.RightChild == null)
                        {
                            temp = null;
                            parent.LeftChild = temp;
                        }
                    }

                }

                _count--;


            }
            else
            {
                return false;
            }


            //bool isLeft = (target == parent.LeftChild);

            //if (target == _root)
            //{
            //    current = FindLastLeftNode(parent.RightChild);
            //    if (current != null)
            //    {
            //        current.LeftChild = parent.LeftChild;
            //        current.RightChild = parent.RightChild;
            //        _root = current;
            //    }
            //}
            //else if (target.IsLeaf())
            //{
            //    if (isLeft)
            //    {
            //        parent.LeftChild = null;
            //    }
            //    else
            //    {
            //        parent.RightChild = null;
            //    }
            //}
            //else if (target.LeftChild != null && target.RightChild != null) //two children
            //{
            //    if (isLeft)
            //    {
            //        parent.LeftChild = target.RightChild;
            //        parent.LeftChild = target.LeftChild;
            //    }
            //    else
            //    {
            //        parent.RightChild = target.RightChild;
            //        parent.RightChild = target.LeftChild;
            //    }
            //}
            //else    //one child 
            //{
            //    if (target.LeftChild == null)
            //    {
            //        if (isLeft)
            //        {
            //            parent.LeftChild = target.LeftChild;
            //        }
            //        else
            //        {
            //            parent.RightChild = target.LeftChild;
            //        }
            //    }
            //    else
            //    {
            //        if (isLeft)
            //        {
            //            parent.LeftChild = target.LeftChild;
            //        }
            //        else
            //        {
            //            parent.RightChild = target.RightChild;
            //        }
            //    }
            //}


            return true;
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
            int leftside = 0;
            int rightside = 0;

            if (r == null)
            {
                height = 0;
            }
            else
            {

                leftside = HeightHelper(r.LeftChild);

                rightside = HeightHelper(r.RightChild);

                height = Math.Max(leftside, rightside) + 1;

            }

            return height;
        }

        //returns an Array representation of the values in the BST using in-order traversal.
        public char[] ToArray()
        {
            char[] array = new char[Count()];
            int i = 0;
            foreach (var item in InorderTraversal(_root))
            {
                array[i] = item;
                i++;
            }

            return array;

            //return array;
        }

        //public class AVLTree
        //{

        //}

    }
}
