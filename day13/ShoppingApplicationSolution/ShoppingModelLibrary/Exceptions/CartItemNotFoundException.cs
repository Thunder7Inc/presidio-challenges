using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartItemNotFoundException : Exception
    {
        string message;
        public CartItemNotFoundException()
        {
            message = "Cart item with the given Ids is not present!";
        }
        public CartItemNotFoundException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
