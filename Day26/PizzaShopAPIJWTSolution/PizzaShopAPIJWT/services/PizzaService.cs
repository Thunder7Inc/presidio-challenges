using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model;

namespace PizzaShopAPIJWT.services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _pizzaMenuRepo;
        //private readonly IRepository<int, PizzaStock> _pizzaStockRepo;
        public PizzaService(IRepository<int, Pizza> pizzaMenu)
        {
            _pizzaMenuRepo = pizzaMenu;
            //_pizzaStockRepo=pizzaStock;
        }

        public async Task<IEnumerable<Pizza>> GetMenu()
        {
            var pizza = await _pizzaMenuRepo.Get();
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> GetMenuInStock()
        {
            //var inStock = await _pizzaStockRepo.Get();
            var pizza = await _pizzaMenuRepo.Get();
            var available = pizza.Where(p => p.Availability == "Available");
            return (IEnumerable<Pizza>)available;
        }

        
    }
}
