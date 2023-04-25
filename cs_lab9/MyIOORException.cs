using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lab9
{
    internal class MyIOORException : Exception
    {
        public int Index { get; }
        public MyIOORException() : base() { }
        public MyIOORException(string message, int index) : base(message)
        { 
            Index = index;
        }
    }
}
