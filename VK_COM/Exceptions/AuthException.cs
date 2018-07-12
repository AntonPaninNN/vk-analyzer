using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VK_COM.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException(string message)
            : base(message)
        { }
    }
}
