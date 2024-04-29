using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public interface ICartItemRepository
    {
        Task<CartItem> Add(CartItem item);
        Task<ICollection<CartItem>> GetAll();
        Task<CartItem> Delete(int cartId, int productId);
        Task<CartItem> Update(CartItem item);
        Task<CartItem> GetByKey(int cartId, int productId);
    }
}