using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public interface ICartService
    { 
        Task<Cart> AddProductToCart(int cartId, int productId, int quantity);

        Task<Cart> RemoveProductFromCart(int cartId, int productId);

        Task<Cart> GetCartById(int cartId);

        Task<IEnumerable<Cart>> GetAllCarts();

        Task<double> CalculateShippingCharges(Cart cart);
        Task<double> ApplyDiscounts(Cart cart);
        Task<bool>  ExceedsMaxQuantityLimit(Cart cart, int productId, int quantity);

        Task IncreaseCartItemQuantity(Cart cart, int productId, int quantity);

        Task DecreaseCartItemQuantity(Cart cart, int productId, int quantity);
    }
}
