using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class InvalidCustomerDataException : Exception
    {
        string message;
        public InvalidCustomerDataException()
        {
            message = "Item with the given Id is not present!";
        }
        public InvalidCustomerDataException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
