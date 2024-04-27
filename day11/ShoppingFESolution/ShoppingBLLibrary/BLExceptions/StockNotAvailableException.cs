using System;

namespace ShoppingBLLibrary.BLExceptions
{
    public class StockNotAvailableException : Exception
    {
        string msg;
        public StockNotAvailableException()
        {
            msg = "Stock not available.";
        }
        public override string Message => msg;
    }
}
