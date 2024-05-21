using PizzaShopAPIJWT.model;
namespace PizzaShopAPIJWT.interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetMenu();
        public Task<IEnumerable<Pizza>> GetMenuInStock();
    }
}
