using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart : IEquatable<Cart>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//Navigation property

        public List<CartItem> CartItems { get; set; }//Navigation property

        // Default constructor
        public Cart()
        {
         
            CartItems = new List<CartItem>();
        }

        // Parameterized constructor
        public Cart(int id, int customerId)
        {
            Id = id;
            CustomerId = customerId;
            CartItems = new List<CartItem>(); 
        }

        public override string ToString()
        {
            return $"Id: {Id}, CustomerId: {CustomerId}";
        }

        public bool Equals(Cart? other)
        {
            return this.Id.Equals(other.Id);
        }
    }

    
}
