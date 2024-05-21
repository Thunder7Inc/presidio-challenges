using PizzaShopAPIJWT.model.DTOs;
using PizzaShopAPIJWT.model;

namespace PizzaShopAPIJWT.interfaces
{
    public interface IUserService
    {
        public Task<Customer> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerUserDTO customerDTO);
    }
}
