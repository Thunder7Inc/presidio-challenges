using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary;

namespace ShoppingBLLibrary
{
    public class CustomerService : ICustomerService
    {
        private readonly AbstractRepository<int, Customer> _customerRepository;

        public CustomerService(AbstractRepository<int, Customer> repository)
        {
            _customerRepository = repository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer data cannot be null.");
            }

            // Check if the customer already exists
            var existingCustomer = await _customerRepository.GetByKey(customer.Id);
            if (existingCustomer != null)
            {
                throw new DuplicateCustomerException($"Customer with ID {customer.Id} already exists.");
            }

            return await _customerRepository.Add(customer);
        }

        public async Task DeleteCustomer(int customerId)
        {
            Customer customer = await _customerRepository.GetByKey(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
            }

            await _customerRepository.Delete(customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            Customer customer = await _customerRepository.GetByKey(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
            }

            return customer;
        }

        public async Task<IEnumerable<Customer>> SearchCustomersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidCustomerDataException("Name cannot be empty.");
            }

            var customers = await _customerRepository.GetAll();
            return customers.Where(c => c.Name.Contains(name)).ToList();
        }

        public async Task<IEnumerable<Customer>> SearchCustomersByAge(int minAge, int maxAge)
        {
            if (minAge < 0 || maxAge < 0 || minAge > maxAge)
            {
                throw new InvalidCustomerDataException("Invalid age range.");
            }

            var customers = await _customerRepository.GetAll();
            return customers.Where(c => c.Age >= minAge && c.Age <= maxAge).ToList();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer data cannot be null.");
            }

            Customer existingCustomer = await _customerRepository.GetByKey(customer.Id);
            if (existingCustomer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customer.Id} not found.");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Age = customer.Age;

            return await _customerRepository.Update(existingCustomer);
        }
    }
}
