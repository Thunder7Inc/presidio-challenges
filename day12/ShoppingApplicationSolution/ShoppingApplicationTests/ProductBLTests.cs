using NUnit.Framework;
using ShoppingBLLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingApplicationTests
{
    public class ProductServiceTests
    {
        private IProductService _productService;
        private AbstractRepository<int, Product> _productRepository;

        [SetUp]
        public void Setup()
        {
            // Initialize the repository
            _productRepository = new ProductRepository();

            // Initialize the service
            _productService = new ProductService(_productRepository);
        }

        [Test]
        public async Task AddProduct_ValidProduct_ReturnsAddedProduct()
        {
            // Arrange
            Product newProduct = new Product { Id = 1, Name = "Product1", Price = 10.0, QuantityInHand = 100 };

            // Act
            Product addedProduct = await _productService.AddProduct(newProduct);
            var allProducts = await _productRepository.GetAll();
            // Assert
            Assert.AreEqual(newProduct, addedProduct);
            Assert.IsTrue(allProducts.Contains(newProduct));
        }

        [Test]
        public void AddProduct_DuplicateProduct_ThrowsException()
        {
            // Arrange
            Product existingProduct = new Product { Id = 1, Name = "Product1", Price = 10.0, QuantityInHand = 100 };

            // Add the existing product
            _productService.AddProduct(existingProduct);

            // Assert
            Assert.Throws<DuplicateProductException>(() => _productService.AddProduct(existingProduct));
        }

        [Test]
        public async Task DeleteProduct_ExistingProductId_RemovesProduct()
        {
            // Arrange
            int productIdToDelete = 1;
            Product productToDelete = new Product { Id = productIdToDelete, Name = "Product1", Price = 10.0, QuantityInHand = 100 };

            // Add the product
            _productService.AddProduct(productToDelete);

            // Act
            _productService.DeleteProduct(productIdToDelete);

            // Assert
            var allProducts = await _productRepository.GetAll();
            Assert.IsFalse(allProducts.Contains(productToDelete));
        }

        [Test]
        public void DeleteProduct_NonExistingProductId_ThrowsException()
        {
            // Arrange
            int nonExistingProductId = 100;

            // Assert
            Assert.Throws<ProductNotFoundException>(() => _productService.DeleteProduct(nonExistingProductId));
        }

        [Test]
        public async Task GetProductById_ExistingProductId_ReturnsProduct()
        {
            // Arrange
            int existingProductId = 1;
            Product existingProduct = new Product { Id = existingProductId, Name = "Product1", Price = 10.0, QuantityInHand = 100 };

            // Add the product
            _productService.AddProduct(existingProduct);

            // Act
            Product retrievedProduct = await _productService.GetProductById(existingProductId);

            // Assert
            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual(existingProductId, retrievedProduct.Id);
        }

        [Test]
        public void GetProductById_NonExistingProductId_ThrowsException()
        {
            // Arrange
            int nonExistingProductId = 100;

            // Assert
            Assert.Throws<ProductNotFoundException>(() => _productService.GetProductById(nonExistingProductId));
        }

        [Test]
        public async Task SearchProductsByName_ExistingName_ReturnsMatchingProducts()
        {
            // Arrange
            var product1 = new Product { Id = 1, Name = "Product1", Price = 10.0, QuantityInHand = 100 };
            var product2 = new Product { Id = 2, Name = "Product2", Price = 15.0, QuantityInHand = 200 };
            _productService.AddProduct(product1);
            _productService.AddProduct(product2);

            // Act
            var searchResults = await _productService.SearchProductsByName("Product1");

            // Convert searchResults to a list
            var searchResultsList = searchResults.ToList();

            // Assert
            Assert.Contains(product1, searchResultsList);
        }




        [Test]
        public void SearchProductsByName_EmptyName_ThrowsException()
        {
            // Assert
            Assert.Throws<InvalidProductDataException>(() => _productService.SearchProductsByName(string.Empty));
        }

        [Test]
        public async Task SearchProductsByPriceRange_ValidRange_ReturnsMatchingProducts()
        {
            // Arrange
            var product1 = new Product { Id = 1, Name = "Product1", Price = 10.0, QuantityInHand = 100 };
            var product2 = new Product { Id = 2, Name = "Product2", Price = 15.0, QuantityInHand = 200 };
            _productService.AddProduct(product1);
            _productService.AddProduct(product2);

            // Act
            var searchResults = await _productService.SearchProductsByPriceRange(5.0, 15.0);

            // Assert
            Assert.Contains(product1, searchResults.ToList());
            Assert.Contains(product2, searchResults.ToList());
        }

        [Test]
        public void SearchProductsByPriceRange_InvalidRange_ThrowsException()
        {
            // Assert
            Assert.Throws<InvalidProductDataException>(() => _productService.SearchProductsByPriceRange(20.0, 10.0));
        }

        [Test]
        public async Task UpdateProduct_ExistingProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            int existingProductId = 1;
            Product updatedProduct = new Product { Id = existingProductId, Name = "UpdatedProduct1", Price = 15.0, QuantityInHand = 200 };

            // Add the product
            _productService.AddProduct(new Product { Id = existingProductId, Name = "Product1", Price = 10.0, QuantityInHand = 100 });

            // Act
            Product returnedProduct = await _productService.UpdateProduct(updatedProduct);

            // Assert
            Assert.AreEqual(updatedProduct, returnedProduct);

            var existingProduct = await _productRepository.GetByKey(existingProductId);
            Assert.AreEqual("UpdatedProduct1", existingProduct.Name);
        }

        [Test]
        public void UpdateProduct_NonExistingProduct_ThrowsException()
        {
            // Arrange
            Product nonExistingProduct = new Product { Id = 100, Name = "NonExistingProduct", Price = 20.0, QuantityInHand = 50 };

            // Assert
            Assert.Throws<ProductNotFoundException>(() => _productService.UpdateProduct(nonExistingProduct));
        }
    }
}
