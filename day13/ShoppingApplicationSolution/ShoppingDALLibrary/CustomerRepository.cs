using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
                return customer;
            }
            throw new CustomerNotFoundException($"No Customer with ID {key} found to delete!");
        }

        public override async Task<Customer> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new CustomerNotFoundException($"No Customer with ID {key} found!");
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != null)
            {
                customer.Name = item.Name;  
                customer.Phone = item.Phone;
                customer.Age = item.Age;
                return customer;
            }
            throw new CustomerNotFoundException($"No Customer with ID {item.Id} found!");
        }
    }
}