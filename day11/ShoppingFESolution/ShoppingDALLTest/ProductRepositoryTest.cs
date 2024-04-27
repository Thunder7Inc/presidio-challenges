
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShoppingDALTest
{
    public class ProductRepositoryTest
    {
        IRepository<int, Product> repository;

        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();

            Product product = new Product() { ProductId = 1, Price = 100.0, Name = "Product1", Image = null, QuantityInHand = 10 };
            repository.Add(product);
        }

        // ADD
        [Test]
        public void AddSuccessTest()
        {
            Product product = new Product() { ProductId = 2, Price = 200.0, Name = "Product2", Image = null, QuantityInHand = 20 };
            var result = repository.Add(product);
            Assert.AreEqual(2, result.ProductId);
        }

        [Test]
        public void AddFailTest()
        {
            Product product = new Product() { ProductId = 3, Price = 300.0, Name = "Product3", Image = null, QuantityInHand = 30 };
            var result = repository.Add(product);
            Assert.AreNotEqual(2, result.ProductId);
        }

        // GET BY ID
        [Test]
        public void GetSuccessTest()
        {
            int productId = 1;
            var result = repository.GetByKey(productId);
            Assert.AreEqual(productId, result.ProductId);
        }

        [Test]
        public void GetFailTest()
        {
            int productId = 999; // Non-existent productId
            Assert.Throws<NoProductWithGivenIdException>(() => repository.GetByKey(productId));
        }

        // GET ALL
        [Test]
        public void GetAllSuccessTest()
        {
            var result = repository.GetAll();
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetAllFailTest()
        {
            var delete = repository.Delete(1);
            var result = repository.GetAll();
            Assert.IsEmpty(result);
        }

        // UPDATE
        [Test]
        public void UpdateSuccessTest()
        {
            Product product = new Product() { ProductId = 2, Price = 250.0, Name = "Product2", Image = null, QuantityInHand = 25 };
            var addedProduct = repository.Add(product);
            var result = repository.Update(product);
            Assert.AreEqual(2, result.ProductId);
        }

        [Test]
        public void UpdateFailTest()
        {
            int productId = 1;
            var product = repository.GetByKey(productId);
            var result = repository.Delete(productId);
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Update(product)); ;
        }

        //DELETE
        [Test]
        public void DeleteSuccessTest()
        {
            int productId = 1;
            var result = repository.Delete(productId);
            Assert.AreEqual(1, result.ProductId);
        }

        [Test]
        public void DeleteFailTest()
        {
            int productId = 999; // Non-existent productId
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Delete(productId));
        }
    }
}