using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        string message;
        public CustomerNotFoundException()
        {
            message = "Customer with the given Id is not present!";
        }
        public CustomerNotFoundException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
