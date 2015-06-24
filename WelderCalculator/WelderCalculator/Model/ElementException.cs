using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Model
{
    public class ElementException : Exception
    {
        public ElementException() { }

        public ElementException(string message) : base(message) { }

    }
}
