using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem : IComparable<CartItem>
    {
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }
        public int CompareTo(CartItem other)
        {
            // Implement comparison logic here...
            // For example, you might compare by ProductId:
            return this.ProductId.CompareTo(other.ProductId);
        }

    }
}