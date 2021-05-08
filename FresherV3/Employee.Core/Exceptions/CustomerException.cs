using System;

namespace MISA.Core.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message)
        {
        }
    }
}