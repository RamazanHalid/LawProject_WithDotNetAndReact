
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.CustomExceptions
{
    public class UnauthorizedUsertException : Exception
    {
        public UnauthorizedUsertException()
        {

        }
        public UnauthorizedUsertException(string message) : base(message)
        {

        }
        public UnauthorizedUsertException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
