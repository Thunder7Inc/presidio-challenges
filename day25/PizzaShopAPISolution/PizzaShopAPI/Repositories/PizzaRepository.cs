using PizzaShopAPI.interfaces;
using PizzaShopAPI.models;
using PizzaShopAPI.context;
using Microsoft.EntityFrameworkCore;

namespace PizzaShopAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaShopContext _context;

        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pizza> DeleteById(int id)
        {
            var pizza = await GetById(id);
            if (pizza != null)
            {

                _context.Remove(pizza);
                await _context.SaveChangesAsync();


            }
            return pizza;

        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            return pizzas;

        }

        public async Task<Pizza> GetById(int id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.PId == id);
            return pizza;
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            var pizza = await GetById(entity.PId);
            if (pizza != null)
            {
                var result = _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            return pizza;
        }
    }
}
