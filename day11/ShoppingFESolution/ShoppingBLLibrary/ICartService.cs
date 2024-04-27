using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        
        public bool CheckMaximumQuantity(int cartId);
        public Cart CheckForDiscount(int cartId);
        public bool ShippingCharges(int cartId);
        public Cart AddToCart(int cartId, CartItem item);

    }
}
