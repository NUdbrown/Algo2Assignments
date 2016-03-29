using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxHeap;

namespace MaxHeapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();

            pq.Enqueue(26, 3);
            pq.Enqueue(24, 3);
            pq.Enqueue(5, 3);
            pq.Enqueue(20, 3);
            pq.Enqueue(16, 3);

            pq.Enqueue(14, 3);
            pq.Enqueue(12, 3);        
            pq.Enqueue(9, 3);
            pq.Enqueue(10, 3);
            pq.Enqueue(6, 3);
            pq.Enqueue(1, 3);

            //Console.WriteLine("COUNT: " + pq.Count()); //works
            ////Console.WriteLine("PEAK: " + pq.Peek().Priority); //works
            //Console.WriteLine("TOSTRING: " + pq.ToString()); //works

            //Console.WriteLine("DEQUEUE: " + pq.Dequeue());
            //Console.WriteLine("TOSTRING: " + pq.ToString()); //works
            //Console.WriteLine("COUNT: " + pq.Count()); //works


            for (int i = 0; i < pq.ToSortedArray().Length; i++)
            {
                Console.WriteLine(pq.ToSortedArray()[i].Priority);
            }



        }
    }
}
