using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class InvalidProductDataException : Exception
    {
        string message;
        public InvalidProductDataException()
        {
            message = "Item with the given Id is not present!";
        }
        public InvalidProductDataException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
