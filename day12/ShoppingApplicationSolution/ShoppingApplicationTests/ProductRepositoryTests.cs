
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;

namespace ShoppingApplicationTests
{
    public class ProductRepositoryTests
    {
        private ProductRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
            // Initialize repository with some initial data if needed
            repository.Add(new Product(1, 10.0, "Product1", 100));
            repository.Add(new Product(2, 20.0, "Product2", 200));
        }

        [Test]
        public async Task Add_ValidProduct_ReturnsAddedProduct()
        {
            // Arrange
            Product newProduct = new Product(3, 30.0, "Product3", 300);

            // Act
            Product addedProduct = await repository.Add(newProduct);

            // Assert
            Assert.AreEqual(newProduct, addedProduct);

            // Await GetAll() before using Contains()
            IEnumerable<Product> allProducts = await repository.GetAll();
            Assert.IsTrue(allProducts.Contains(newProduct));
        }


        [Test]
        public void Add_DuplicateProduct_ThrowsException()
        {
            // Arrange
            Product existingProduct = new Product(1, 10.0, "Product1", 100);

            // Assert
            Assert.Throws<DuplicateItemFoundException>(() => repository.Add(existingProduct));
        }

        [Test]
        public async Task Delete_ExistingProductId_RemovesProduct()
        {
            // Arrange
            int productIdToDelete = 1;

            // Act
            Product deletedProduct = await repository.Delete(productIdToDelete);


            // Assert
            var allProducts = await repository.GetAll();
            Assert.AreEqual(1, allProducts.Count);
            Assert.IsFalse(allProducts.Contains(deletedProduct));
        }

        [Test]
        public void Delete_NonExistingProductId_ThrowsException()
        {
            // Arrange
            int nonExistingProductId = 100;

            // Assert
            Assert.Throws<ProductNotFoundException>(() => repository.Delete(nonExistingProductId));
        }

        [Test]
        public async Task GetByKey_ExistingProductId_ReturnsProduct()
        {
            // Arrange
            int existingProductId = 2;

            // Act
            Product retrievedProduct = await repository.GetByKey(existingProductId);

            // Assert
            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual(existingProductId, retrievedProduct.Id);
        }

        [Test]
        public void GetByKey_NonExistingProductId_ThrowsException()
        {
            // Arrange
            int nonExistingProductId = 100;

            // Assert
            Assert.Throws<ProductNotFoundException>(() => repository.GetByKey(nonExistingProductId));
        }

        [Test]
        public async Task Update_ExistingProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            int existingProductId = 1;
            Product updatedProduct = new Product(existingProductId, 15.0, "UpdatedProduct", 150);

            // Act
            Product returnedProduct = await repository.Update(updatedProduct);

            // Assert
            Assert.AreEqual(updatedProduct, returnedProduct);

            // Await GetByKey before accessing properties
            Product retrievedProduct = await repository.GetByKey(existingProductId);
            Assert.AreEqual("UpdatedProduct", retrievedProduct.Name);
            Assert.AreEqual(15.0, retrievedProduct.Price);
            Assert.AreEqual(150, retrievedProduct.QuantityInHand);
        }


        [Test]
        public void Update_NonExistingProduct_ThrowsException()
        {
            // Arrange
            Product nonExistingProduct = new Product(100, 100.0, "NonExistingProduct", 1000);

            // Assert
            Assert.Throws<ProductNotFoundException>(() => repository.Update(nonExistingProduct));
        }
    }
}
