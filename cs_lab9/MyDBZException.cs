using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lab9
{
    internal class MyDBZException : DivideByZeroException
    {
        public double Argument { get; }
        public double Value { get; }

        public MyDBZException() : base() { }
        public MyDBZException(string message, double argument) : base(message)
        {
            Argument = argument;
        }
        public MyDBZException(string message, double argument, double value) : base(message)
        {
            Argument = argument;
            Value = value;
        }
    }
}
