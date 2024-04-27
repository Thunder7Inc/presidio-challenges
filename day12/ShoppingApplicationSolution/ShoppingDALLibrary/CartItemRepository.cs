using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : ICartItemRepository
    {
        private IList<CartItem> items = new List<CartItem>();

        public async Task<CartItem> Add(CartItem item)
        {
            if (items.Contains(item))
            {
                throw new DuplicateItemFoundException("Cart Item already exists in the repository.");
            }
            items.Add(item);
            return item;
        }

        public async Task<CartItem> Delete(int cartId, int productId)
        {
            CartItem item = await GetByKey(cartId, productId);
            if (item != null)
            {
                items.Remove(item);
                return item;
            }
            throw new KeyNotFoundException($"CartItem with CartId: {cartId} and ProductId: {productId} not found.");
        }

        public async Task<CartItem> Update(CartItem item)
        {
            CartItem existingItem = await GetByKey(item.CartId, item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                existingItem.Price = item.Price;
                existingItem.Discount = item.Discount;
                existingItem.PriceExpiryDate = item.PriceExpiryDate;
                return existingItem;
            }
            throw new KeyNotFoundException($"CartItem with CartId: {item.CartId} and ProductId: {item.ProductId} not found.");
        }

        public async Task<CartItem> GetByKey(int cartId, int productId)
        {
            CartItem cartItem = items.FirstOrDefault(item => item.CartId == cartId && item.ProductId == productId);
            if (cartItem == null)
            {
                throw new KeyNotFoundException($"Cart item with CartId: {cartId} and ProductId: {productId} was not found.");
            }
            return cartItem;
        }

        public async Task<ICollection<CartItem>> GetAll()
        {
            return items;
        }
    }
}
