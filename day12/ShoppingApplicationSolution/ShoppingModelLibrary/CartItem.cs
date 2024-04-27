using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem : IEquatable<CartItem>
    {
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }


        public CartItem()
        {
        }

    
        public CartItem(int cartId, int productId, int quantity, double price, double discount, DateTime priceExpiryDate)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }

        public override string ToString()
        {
            return $"CartId: {CartId}, ProductId: {ProductId}, Quantity: {Quantity}, Price: {Price}, Discount: {Discount}, PriceExpiryDate: {PriceExpiryDate}";
        }

        public bool Equals(CartItem? other)
        {
            return this.CartId.Equals(other.CartId) && this.ProductId.Equals(other.ProductId);
        }
    }
}