using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model;
using PizzaShopAPIJWT.context;
using Microsoft.EntityFrameworkCore;

namespace PizzaShopAPIJWT.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private PizzaShopContext context;
        public PizzaRepository(PizzaShopContext _context)
        {
            context = _context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            context.Add(item);
            await context.SaveChangesAsync();
            return item;

        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                context.Remove(pizza);
                await context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No pizza with the given ID");
        }

        public async Task<Pizza> Get(int key)
        {
            return (await context.Pizzas.SingleOrDefaultAsync(p => p.Id == key)) ?? throw new Exception("No pizza with the given ID");
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return (await context.Pizzas.ToListAsync());
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.Id);
            if (pizza != null)
            {
                context.Update(item);
                await context.SaveChangesAsync();
                return pizza;
            }
            throw new Exception("No pizza with the given ID");
        }
    }
}
