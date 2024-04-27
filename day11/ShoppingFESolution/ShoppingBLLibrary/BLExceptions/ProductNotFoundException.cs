using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.BLExceptions
{
    public class ProductNotFoundException : Exception
    {
        string msg;
        public ProductNotFoundException()
        {
            msg = "Product not found.";
        }
        public override string Message => msg;
    }
}
