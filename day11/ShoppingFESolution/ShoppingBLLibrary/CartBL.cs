using ShoppingBLLibrary.BLExceptions;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBL
{
    public class CartBL : ICartService
    {
        readonly AbstractRepository<int, Cart> _abstractRepository;
        private readonly ProductRepository _productRepository;

        public CartBL(AbstractRepository<int, Cart> abstractRepository, ProductRepository productRepository)
        {
            _abstractRepository = abstractRepository;
            _productRepository = productRepository;
        }

        public bool ShippingCharges(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                double totalPrice = 0;
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { totalPrice += _productRepository.GetByKey(item.ProductId).Price * item.Quantity; });

                    return totalPrice > 100;
                }
            }
            throw new NoCartWithGivenIdException();
        }

        public bool CheckMaximumQuantity(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                if (result.CartItems.Count > 0)
                {
                    foreach (var item in result.CartItems)
                    {
                        if (_productRepository.GetByKey(item.ProductId).QuantityInHand < item.Quantity)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart CheckForDiscount(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                double totalPrice = 0;
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { totalPrice += _productRepository.GetByKey(item.ProductId).Price * item.Quantity; });
                    if (result.CartItems.Count == 3 && totalPrice >= 1500)
                    {
                        totalPrice -= totalPrice * 5 / 100;

                        result.TotalPrice = totalPrice;
                        return result;
                    }
                }
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart AddToCart(int cartId, CartItem item)
        {
            var cart = _abstractRepository.GetByKey(cartId);
            if (cart != null)
            {
                if (_productRepository.GetByKey(item.ProductId).QuantityInHand < item.Quantity)
                {
                    throw new StockNotAvailableException();
                }
                
                if (!CheckMaximumQuantity(cartId))
                {
                    throw new QuantityExceededException();
                }
                cart.CartItems.Add(item);

                cart = CheckForDiscount(cartId);

                bool shippingChargesApply = ShippingCharges(cartId);
                if (shippingChargesApply)
                {
                    cart.TotalPrice += 100;
                }

                _abstractRepository.Update(cart);
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
