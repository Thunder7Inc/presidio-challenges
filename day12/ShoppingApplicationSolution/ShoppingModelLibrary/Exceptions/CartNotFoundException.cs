using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartNotFoundException : Exception
    {
        string message;
        public CartNotFoundException()
        {
            message = "Cart with the given Id is not present!";
        }
        public CartNotFoundException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
