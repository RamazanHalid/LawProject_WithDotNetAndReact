using System;
namespace Core.Utilities.CustomExceptions
{
    public class UnApprovedAccountException : Exception
    {
        public UnApprovedAccountException()
        {
        }
        public UnApprovedAccountException(string message) : base(message)
        {
        }
        public UnApprovedAccountException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
