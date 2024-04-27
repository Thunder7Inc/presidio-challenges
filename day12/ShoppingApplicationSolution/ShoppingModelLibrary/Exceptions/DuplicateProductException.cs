using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class DuplicateProductException : Exception
    {
        string message;
        public DuplicateProductException()
        {
            message = "Item with the given Id is not present!";
        }
        public DuplicateProductException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
