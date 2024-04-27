using ShoppingModelLibrary;
using ShoppingDALLibrary;
using ShoppingBLLibrary.BLExceptions;

namespace ShoppingBLLibrary
{
    public class ProductBL
    {
        public ProductRepository _productRepository;

        public ProductBL(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public double GetPriceByProductId(int productId)
        {
            var product = _productRepository.GetByKey(productId);
            if (product != null)
            {
                return product.Price;
            }
            else
            {
                throw new ProductNotFoundException();
            }
        }
        public int GetQuantityByProductId(int productId)
        {
            var product = _productRepository.GetByKey(productId);
            if (product != null)
            {
                if (product.QuantityInHand == 0)
                {
                    throw new StockNotAvailableException();
                }
                return product.QuantityInHand;
            }
            else
            {
                throw new ProductNotFoundException();
            }
        }
    }
}
