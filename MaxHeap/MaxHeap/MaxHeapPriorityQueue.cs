using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    public class MaxHeapPriorityQueue
    {
        private int _count = 0;
        private PQNode[] _holdthis = new PQNode[2];

        /** Takes in the priority and value as parameters.Creates a new PQNode with this value and adds the node to the queue,       
        adjusts the count, and heapifies as needed. When heapifying, a child node with equal priority to its parent does NOT
        promote and the heapifying of that particular child node stops.
            1. ignore zero
            2. priority matters
            3. p = n , left = 2n, right = 2n + 1
        **/
        public void Enqueue(int priority, int value)
        {
            _count++;
            PQNode addThis = new PQNode(priority, value);

            if (_count == _holdthis.Length)
            {
                PQNode[] doubleHold = new PQNode[_holdthis.Length * 2];

                Array.Copy(_holdthis, 0, doubleHold, 0, _count);
                _holdthis = doubleHold;
            }

            _holdthis[_count] = addThis;

            if (_count > 1)
            {
                HeapifyUp(_count);

            }

        }

        private void HeapifyUp(int pos)
        {
            if (pos > 1)
            {
                int parentPos = (pos) / 2;

                if (_holdthis[pos].Priority > _holdthis[parentPos].Priority)
                {
                    PQNode temp = _holdthis[parentPos];
                    _holdthis[parentPos] = _holdthis[pos];
                    _holdthis[pos] = temp;

                    HeapifyUp(parentPos);
                }
            }


        }


        //returns the root node of the queue (without removing it)
        public PQNode Peek()
        {
            return _holdthis[1];
        }

        //Removes the root node of the queue and returns it, adjusts the count, and heapifies as needed.
        public PQNode Dequeue()
        {
            PQNode temp = _holdthis[1];
            _holdthis[1] = _holdthis[_count];
            _holdthis[_count] = null;

            _count--;

            HeapifyDown(1);

            return temp;
        }


        public void HeapifyDown(int pos)
        {
            if (pos <= _count/2)
            {

                if (_holdthis[pos*2] != null && _holdthis[(pos*2) + 1] == null)
                {
                    if (_holdthis[pos].Priority < _holdthis[pos*2].Priority)
                    {
                        PQNode temp = _holdthis[pos*2];
                        _holdthis[pos*2] = _holdthis[pos];
                        _holdthis[pos] = temp;

                        HeapifyDown(pos*2);
                    }
                }
                else if(_holdthis[pos * 2] != null && _holdthis[(pos * 2)+1] != null && _holdthis[pos * 2].Priority > _holdthis[(pos * 2) + 1].Priority)
                {
                    PQNode temp = _holdthis[pos * 2];
                    _holdthis[pos * 2] = _holdthis[pos];
                    _holdthis[pos] = temp;

                    HeapifyDown(pos * 2);
                }
                else
                {
                    PQNode temp = _holdthis[(pos * 2) + 1];
                    _holdthis[(pos * 2) + 1] = _holdthis[pos];
                    _holdthis[pos] = temp;

                    HeapifyDown((pos * 2) + 1);
                }

            }

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
            string item = "";

            for (int i = 1; i <= _count; i++)
            {
                item += _holdthis[i].Priority + ":" + _holdthis[i].Value + ", ";
            }

            return item.Remove(item.Length - 2);

        }

        /**Using heapsort, produce and return an array of PQNode instances sorted in non-decreasing order of priority.
           Despite the typical convention of ignoring index 0 of the backing array, the array you return from this method 
           should start at 0 and continue to index n-1 (like a typical array in Java or C#)     
         **/
        public PQNode[] ToSortedArray()
        {
            PQNode [] outputArray = new PQNode[_count];
            Array.Copy(_holdthis, 1, outputArray, 0, _count);

            int pos = outputArray.Length;

            while (pos < outputArray.Length && pos != 0)
            {
                pos--;
                
                    PQNode temp = outputArray[0];
                    outputArray[0] = outputArray[pos];
                    outputArray[pos] = temp;

                    HeapifyDown(0);                 
               

            }

            return outputArray;
        }
    }
}
