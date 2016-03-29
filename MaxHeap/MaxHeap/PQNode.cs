using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxHeap
{
    public class PQNode
    {
        private int _value;
        private int _priority;

        public PQNode(int priority, int value)
        {
            this._value = value;
            this._priority = priority;
        }

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                value = _value;
            }

        }

        public int Priority
        {
            get { return _priority; }
            set { value = _priority; }
        }

        //public bool Contains(T value)
        //{
        //    int result = value.CompareTo(_value);
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
