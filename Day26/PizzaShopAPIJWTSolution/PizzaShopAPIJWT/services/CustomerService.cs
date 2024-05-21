using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model;

namespace PizzaShopAPIJWT.services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Customer> _repository;

        public CustomerService(IRepository<int, Customer> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = (await _repository.Get()).FirstOrDefault(e => e.Id == id);
            if (customer == null)
                throw new Exception();
            return customer;

        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _repository.Get();
            if (customers.Count() == 0)
                throw new Exception();
            return customers;
        }

        public async Task<Customer> UpdateCustomerPhone(int id, string phoneNumber)
        {
            var customer = await _repository.Get(id);
            if (customer == null)
                throw new Exception();
            customer.Phone = phoneNumber;
            customer = await _repository.Update(customer);
            return customer;
        }
    }
}
