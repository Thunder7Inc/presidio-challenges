using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class InsufficientQuantityException : Exception
    {
        string message;
        public InsufficientQuantityException()
        {
            message = "Insufficient Quantity Found!";
        }
        public InsufficientQuantityException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
