using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class DuplicateItemFoundException : Exception
    {
        string message;
        public DuplicateItemFoundException()
        {
            message = "Item with the given Id is not present!";
        }
        public DuplicateItemFoundException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
