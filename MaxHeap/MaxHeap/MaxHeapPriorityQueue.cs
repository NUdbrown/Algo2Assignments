using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    public class MaxHeapPriorityQueue<T> where T : IComparable<T>
    {
        PQNode<T> _root = new PQNode<T>();
        private int _count = 0;

        /** Takes in the priority and value as parameters.Creates a new PQNode with this data and adds the node to the queue,       
        adjusts the count, and heapifies as needed. When heapifying, a child node with equal priority to its parent does NOT
        promote and the heapifying of that particular child node stops.
        **/
        public void Enqueue(T priority, T value)
        {
            
        }

        //returns the root node of the queue (without removing it)
        public PQNode<T> Peek()
        {
            return _root;
        }

        //Removes the root node of the queue and returns it, adjusts the count, and heapifies as needed.
        public PQNode<T> Dequeue()
        {
            return _root;
        }

        //returns the total number of nodes in the queue
        public int Count()
        {
            return _count;
        }

        /** displays the elements of the Array-Heap as they are found in memory(i.e.you iterate over the array). 
        The string will have the following format:
        p1:v1, p2:v2, p3:v3,...,pn:vn
        **/
        public override string ToString()
        {

            return base.ToString();
        }

        /**Using heapsort, produce and return an array of PQNode instances sorted in non-decreasing order of priority.
           Despite the typical convention of ignoring index 0 of the backing array, the array you return from this method 
           should start at 0 and continue to index n-1 (like a typical array in Java or C#)     
         **/
         public T[] ToSortedArray()
        {
            return null;
        }
    }
}
