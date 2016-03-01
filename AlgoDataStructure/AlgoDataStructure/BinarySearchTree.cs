using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _root;
        private List<T> _tree = new List<T>();

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
                    else if(value.CompareTo(current.Data) < 0)
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

            //PrintTree();

        }

        //private void PrintTree()
        //{
        //    foreach (var item in _tree)
        //    {
        //        Console.WriteLine("[ " + item + "]");
        //        Console.WriteLine();
        //    }
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
        public void Remove(T value)
        {



            _count--;
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
            string right = "";
            string left = "";
            bool notVisited = true;
            List<T> leftLst = new List<T>();
            List<T> rightLst = new List<T>();


            var temp = new Node<T>(_root.Data);


            Node<T> current = _root;


            while (notVisited)
            {
                Console.WriteLine("this is the current: " + current.Data  + " /"+ current.LeftChild.Data + " left child" + " /" + current.RightChild.Data + " rightchild");
                if (current.LeftChild != null)
                {
                    leftLst.Add(current.LeftChild.Data);
                    current = current.LeftChild;
                }
                else
                {
                    notVisited = false;
                }
                if (current.RightChild != null)
                {
                    rightLst.Add(current.RightChild.Data);
                    current = current.LeftChild;
                }
                else
                {
                    notVisited = false;
                }

            }

            left = LeftPrinting(leftLst, left);

            right = RightPrinting(rightLst, right);

            output = "["+ left + temp.Data + right + "]";
            return output;

        }

        private static string RightPrinting(List<T> rightLst, string right)
        {
            right = rightLst.Aggregate(right, (current, item) => current + (", " + item));
            Console.WriteLine("This is the right: " + right);
            return right;
        }

        private static string LeftPrinting(List<T> leftLst, string left)
        {
            left = leftLst.Aggregate(left, (current, item) => current + (item + ", "));
            Console.WriteLine("This is the left: " + left);
            return left;
        }

        //returns a pre-order string representation of all the values in the BST [Parent, Left, then Right]
        public string Preorder()
        {
            Node<T> current = _root;
            string _out = "";

            //while (current != null)
            //{



            //}

            return _out;
        }

        //returns a post-order string representation of all the values in the BST [Left, Right, then Parent]
        public string Postorder()
        {
            Node<T> current = _root;
            string _out = "";

            //while (current != null)
            //{



            //}

            return _out;
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
        public T[] ToArray()
        {
            Inorder();
            return _tree.ToArray();
        }

        //public class AVLTree
        //{

        //}

    }
}
