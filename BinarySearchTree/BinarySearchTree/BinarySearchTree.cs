using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree
    {
        public void Add(T value)
        {
            
        }
        //adds a new value to the tree, following the rules of a BST.Duplicate values go to the right of the parent.
        public void Contains(T value)
        {
            
        }
        //returns true if the specified value is in the tree.

        public void Remove(T value)
        {
            
        }
        //removes the specified value from the tree if it is present, or does nothing if the value is not present.
        //If the value appears more than once, only the first occurrence of the value is removed.
        //When removing a node with two children, replace it with the next in-order value (or rather the left-most right descendant).
        public void Clear()
        {
            
        }
        //removes all values from the tree.
        public void Count()
        {
            
        }
        //returns the number of values in the tree 
        public void Inorder()
        {
            
        }
        //returns an in-order string representation of all the values in the BST 
        public void Preorder()
        {
            
        }
        //returns a pre-order string representation of all the values in the BST 
        public void Postorder()
        {
            
        } 
        //returns a post-order string representation of all the values in the BST i.All of the “order” functions above return a string in the format of “v1, v2, …, vn”. 
        public void Height()
        {
            
        } 
        //returns the height of the BST, where the empty tree is 0, the simple tree is 1.
    }
}
