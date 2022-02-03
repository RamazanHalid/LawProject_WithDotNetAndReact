using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.CustomExceptions
{
    public class UnApprovedAccountException : Exception
    {
        public int UserId { get; set; }

        public UnApprovedAccountException(int userId)
        {
            UserId = userId;
        }
        public UnApprovedAccountException(int userId, string message) : base(message)
        {
            UserId = userId;
        }
        public UnApprovedAccountException(int userId, string message, Exception inner) : base(message, inner)
        {
            UserId = userId;
        }
    }
}
