using PizzaShopAPI.interfaces;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Service
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }
        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            var result = await _repository.Add(pizza);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Pizza not added");
        }

        public Task<Pizza> DeletePizzaById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            var pizzas = await _repository.GetAll();
            if (pizzas.Count() > 0)
            {
                return pizzas;
            }
            throw new Exception("No pizzas found");
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzasInStock()
        {
            var pizzas = await _repository.GetAll();

            pizzas = pizzas.Where(p => p.Quantity > 0);
            if (pizzas.Count() > 0)
            {
                return pizzas;
            }
            throw new Exception("No pizzas in stock");
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _repository.GetById(id);
            if (pizza != null)
            {
                return pizza;
            }
            throw new Exception("Pizza not found");
        }

        public Task<Pizza> UpdatePizza(Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}
