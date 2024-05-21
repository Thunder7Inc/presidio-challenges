using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model;
using PizzaShopAPIJWT.context;
using Microsoft.EntityFrameworkCore;

namespace PizzaShopAPIJWT.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaShopContext _context;
        public CustomerRepository(PizzaShopContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(Customer item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);
            if (customer != null)
            {
                _context.Remove(customer);
                _context.SaveChangesAsync(true);
                return customer;
            }
            throw new Exception();
        }

        public async Task<Customer> Get(int key)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == key);
            return customer;
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> Update(Customer item)
        {
            var customer = await Get(item.Id);
            if (customer != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return customer;
            }
            throw new Exception();
        }
    }
}
