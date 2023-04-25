using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lab9
{
    internal class MyArgumentException : ArgumentException
    {
        public double Argument { get; }
        public double Value { get; }

        public MyArgumentException() : base() { }
        public MyArgumentException(string message, double argument) : base(message)
        {
            Argument = argument;
        }
        public MyArgumentException(string message, double argument, double value) : base(message)
        {
            Argument = argument;
            Value = value;
        }
    }
}
