using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoItemWithGivenIdException : Exception
    {
        string message;
        public NoItemWithGivenIdException()
        {
            message = "Item with the given Id is not present!";
        }
        public NoItemWithGivenIdException(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}