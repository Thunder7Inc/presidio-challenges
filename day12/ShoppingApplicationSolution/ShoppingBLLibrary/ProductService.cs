using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary;
using System;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public class ProductService : IProductService
    {
        private readonly AbstractRepository<int, Product> _productRepository;

        public ProductService(AbstractRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            if (product == null)
            {
                throw new InvalidProductDataException("Product data cannot be null.");
            }

            // Check if the product already exists
            IEnumerable<Product> allProducts = await _productRepository.GetAll();
            if (allProducts.Any(p => p.Id == product.Id))
            {
                throw new DuplicateProductException($"Product with ID {product.Id} already exists.");
            }

            return await _productRepository.Add(product);
        }

        public async Task DeleteProduct(int productId)
        {
            Product product = await _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }

            await _productRepository.Delete(productId);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product = await _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> SearchProductsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidProductDataException("Name cannot be empty.");
            }

            // Await the result of GetAll before using Where
            IEnumerable<Product> allProducts = await _productRepository.GetAll();
            return allProducts.Where(p => p.Name.Contains(name));
        }


        public async Task<IEnumerable<Product>> SearchProductsByPriceRange(double minPrice, double maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0 || minPrice > maxPrice)
            {
                throw new InvalidProductDataException("Invalid price range.");
            }

            // Await the result of GetAll before using Where
            IEnumerable<Product> allProducts = await _productRepository.GetAll();
            return allProducts.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
        }


        public async Task<Product> UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new InvalidProductDataException("Product data cannot be null.");
            }

            Product existingProduct = await _productRepository.GetByKey(product.Id);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException($"Product with ID {product.Id} not found.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Image = product.Image;
            existingProduct.QuantityInHand = product.QuantityInHand;

            return await _productRepository.Update(existingProduct);
        }
    }
}
