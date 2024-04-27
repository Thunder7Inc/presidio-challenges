using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class MaxQuantityExceededException : Exception
    {
        string message;
        public MaxQuantityExceededException()
        {
            message = "Cart with the given Id is not present!";
        }
        public MaxQuantityExceededException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
