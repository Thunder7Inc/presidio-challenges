using PizzaShopAPIJWT.model;

namespace PizzaShopAPIJWT.interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> UpdateCustomerPhone(int id, string phoneNumber);
        public Task<IEnumerable<Customer>> GetCustomers();
    }
}
