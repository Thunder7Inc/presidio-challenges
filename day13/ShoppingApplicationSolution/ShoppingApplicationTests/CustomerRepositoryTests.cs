using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;

namespace ShoppingApplicationTests
{
    public class CustomerRepositoryTests
    {
        private CustomerRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
            // Initialize repository with some initial data if needed
            repository.Add(new Customer(1, "Somu", "1234567890", 30));
            repository.Add(new Customer(2, "Ramu", "9876543210", 25));
        }

        [Test]
        public async Task Add_ValidCustomer_ReturnsAddedCustomer()
        {
            // Arrange
            Customer newCustomer = new Customer(3, "Somu", "4561237890", 35);

            // Act
            Customer addedCustomer = await repository.Add(newCustomer);

            // Assert
            Assert.AreEqual(newCustomer, addedCustomer);

            // Await GetAll() before using Contains()
            IEnumerable<Customer> allCustomers = await repository.GetAll();
            Assert.IsTrue(allCustomers.Contains(newCustomer));
        }


        [Test]
        public void Add_DuplicateCustomer_ThrowsException()
        {
            // Arrange
            Customer existingCustomer = new Customer(1, "Somu", "1234567890", 30);

            // Assert
            Assert.Throws<DuplicateItemFoundException>(() => repository.Add(existingCustomer));
        }

        [Test]
        public async Task Delete_ExistingCustomerId_RemovesCustomer()
        {
            // Arrange
            int customerIdToDelete = 1;

            // Act
            Customer deletedCustomer = await repository.Delete(customerIdToDelete);

            // Assert
            // Check that the deleted customer is returned by the Delete method
            Assert.IsNotNull(deletedCustomer);

            // Await GetAll() before checking the count and presence of the deleted customer
            IEnumerable<Customer> allCustomers = await repository.GetAll();
            Assert.AreEqual(1, allCustomers.Count());
            Assert.IsFalse(allCustomers.Contains(deletedCustomer));
        }


        [Test]
        public void Delete_NonExistingCustomerId_ThrowsException()
        {
            // Arrange
            int nonExistingCustomerId = 100;

            // Assert
            Assert.Throws<CustomerNotFoundException>(() => repository.Delete(nonExistingCustomerId));
        }

        [Test]
        public async Task GetByKey_ExistingCustomerId_ReturnsCustomer()
        {
            // Arrange
            int existingCustomerId = 2;

            // Act
            Customer retrievedCustomer = await repository.GetByKey(existingCustomerId);

            // Assert
            Assert.IsNotNull(retrievedCustomer);
            Assert.AreEqual(existingCustomerId, retrievedCustomer.Id);
        }

        [Test]
        public void GetByKey_NonExistingCustomerId_ThrowsException()
        {
            // Arrange
            int nonExistingCustomerId = 100;

            // Assert
            Assert.Throws<CustomerNotFoundException>(() => repository.GetByKey(nonExistingCustomerId));
        }

        [Test]
        public async Task Update_ExistingCustomer_ReturnsUpdatedCustomer()
        {
            // Arrange
            int existingCustomerId = 1;
            Customer updatedCustomer = new Customer(existingCustomerId, "Somu Op", "9999999999", 40);

            // Act
            Customer returnedCustomer = await repository.Update(updatedCustomer);

            // Assert
            Assert.AreEqual(updatedCustomer, returnedCustomer);

            // Use await to get the result of GetByKey
            Customer retrievedCustomer = await repository.GetByKey(existingCustomerId);

            Assert.AreEqual("9999999999", retrievedCustomer.Phone);
            Assert.AreEqual(40, retrievedCustomer.Age);
        }


        [Test]
        public void Update_NonExistingCustomer_ThrowsException()
        {
            // Arrange
            Customer nonExistingCustomer = new Customer(100, "Somu", "1231231234", 50);

            // Assert
            Assert.Throws<CustomerNotFoundException>(() => repository.Update(nonExistingCustomer));
        }
    }
}
