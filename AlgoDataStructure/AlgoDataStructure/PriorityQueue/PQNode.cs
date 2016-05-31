using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
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
    }
}
