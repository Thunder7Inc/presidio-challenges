using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ShoppingDALTest
{
    public class CustomerRepositoryTest
    {
        IRepository<int, Customer> repository;

        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();

            Customer customer = new Customer() { CustomerId = 1, Phone = "1234567890", Name = "Customer1", Age = 30 };
            repository.Add(customer);
        }

        // ADD
        [Test]
        public void AddSuccessTest()
        {
            Customer customer = new Customer() { CustomerId = 2, Phone = "0987654321", Name = "Customer2", Age = 40 };
            var result = repository.Add(customer);
            Assert.AreEqual(2, result.CustomerId);
        }

        [Test]
        public void AddFailTest()
        {
            Customer customer = new Customer() { CustomerId = 3, Phone = "1122334455", Name = "Customer3", Age = 50 };
            var result = repository.Add(customer);
            Assert.AreNotEqual(2, result.CustomerId);
        }

        // GET BY ID
        [Test]
        public void GetSuccessTest()
        {
            int customerId = 1;
            var result = repository.GetByKey(customerId);
            Assert.AreEqual(customerId, result.CustomerId);
        }
        
        [Test]
        public void GetFailTest()
        {
            int customerId = 999; // Non-existent customerId
            Assert.Throws<NoCustomerWithGivenIdException>(() => repository.GetByKey(customerId));
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
            Customer customer = new Customer() { CustomerId = 2, Phone = "1020304050", Name = "Customer2", Age = 45 };
            var addedCustomer = repository.Add(customer);
            var result = repository.Update(customer);
            Assert.AreEqual(2, result.CustomerId);
        }

        [Test]
        public void UpdateFailTest()
        {
            int customerId = 1;
            var customer = repository.GetByKey(customerId);
            var result = repository.Delete(customerId);
            Assert.Throws<NoCustomerWithGivenIdException>(() => repository.Update(customer)); ;
        }

        //DELETE
        [Test]
        public void DeleteSuccessTest()
        {
            int customerId = 1;
            var result = repository.Delete(customerId);
            Assert.AreEqual(1, result.CustomerId);
        }

        [Test]
        public void DeleteFailTest()
        {
            int customerId = 999; // Non-existent customerId
            Assert.Throws<NoCustomerWithGivenIdException>(() => repository.Delete(customerId));
        }
    }
}
