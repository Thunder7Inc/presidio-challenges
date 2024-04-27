using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override Customer GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].CustomerId == key)
                    return items[i];
            }
            throw new NoCustomerWithGivenIdException();
        }

        public override Customer Update(Customer item)
        {
            Customer customer = GetByKey(item.CustomerId);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }
}