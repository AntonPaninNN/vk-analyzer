using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VK_COM.Exceptions
{
    public class ArgumetsException : Exception
    {
        public ArgumetsException()
        { }

        public ArgumetsException(string message) : base(message)
        { }
    }
}
