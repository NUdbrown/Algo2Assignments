using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    public class PQNode<T> where T : IComparable<T>
    {
        private T data;
        private T priority;

        public PQNode(T priority, T data)
        {
            this.data = data;
            this.priority = priority;
            LeftChild = null;
            RightChild = null;
        }

        public PQNode<T> LeftChild { get; set; }

        public PQNode<T> RightChild { get; set; }

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

        public T Priority
        {
            get { return priority; }
            set { value = priority; }
        }

        //public bool Contains(T value)
        //{
        //    int result = value.CompareTo(data);
        //    if (result == 0)
        //    {
        //        return true;
        //    }
        //    if (result < 0 && LeftChild != null && LeftChild.Contains(value))
        //    {
        //        return true;
        //    }
        //    if (result > 0 && RightChild != null && RightChild.Contains(value))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
