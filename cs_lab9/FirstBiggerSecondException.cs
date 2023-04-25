using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lab9
{
    internal class FirstBiggerSecondException : Exception
    {
        public int FirstI { get; }
        public int SecondI { get; }

        public FirstBiggerSecondException() : base() { }
        public FirstBiggerSecondException(string message, int firstI, int secondI) : base(message)
        {
            FirstI = firstI;
            SecondI = secondI;
        }
    }
}
