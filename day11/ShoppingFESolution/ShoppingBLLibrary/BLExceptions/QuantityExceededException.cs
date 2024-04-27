using System;

namespace ShoppingBLLibrary.BLExceptions
{
    internal class QuantityExceededException : Exception
    {
        string msg;
        public QuantityExceededException()
        {
            msg = "The maximum quantity of a product in cart cannot be more than 5.";
        }
        public override string Message => msg;
    }
}
