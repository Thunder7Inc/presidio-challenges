using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        // Add a new customer
        Task<Customer> AddCustomer(Customer customer);

        // Update an existing customer
        Task<Customer> UpdateCustomer(Customer customer);

        // Get a customer by their ID
        Task<Customer> GetCustomerById(int customerId);

        // Get all customers
        Task<IEnumerable<Customer>> GetAllCustomers();

        // Delete a customer by their ID
        Task DeleteCustomer(int customerId);

        // Search for customers by name
        Task<IEnumerable<Customer>> SearchCustomersByName(string name);

        // Search for customers by age
        Task<IEnumerable<Customer>> SearchCustomersByAge(int minAge, int maxAge);
    }
}