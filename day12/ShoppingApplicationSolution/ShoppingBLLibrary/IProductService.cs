using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        // Add a new product
        Task<Product> AddProduct(Product product);

        // Update an existing product
        Task<Product> UpdateProduct(Product product);

        // Get a product by its ID
        Task<Product> GetProductById(int productId);

        // Get all products
        Task<IEnumerable<Product>> GetAllProducts();

        // Delete a product by its ID
        Task DeleteProduct(int productId);

        // Search products by name
        Task<IEnumerable<Product>> SearchProductsByName(string name);

        // Search products by price range
        Task<IEnumerable<Product>> SearchProductsByPriceRange(double minPrice, double maxPrice);
    }
}
