using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model.DTOs;
using PizzaShopAPIJWT.model;
using System.Security.Cryptography;
using System.Text;
using PizzaShopAPIJWT.Controllers;

namespace PizzaShopAPIJWT.services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Customer> _customerRepo;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Customer> customerRepo)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
        }
        public async Task<Customer> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var customer = await _customerRepo.Get(loginDTO.UserId);
                if (userDB.Status == "Active")
                    return customer;
                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Customer> Register(CustomerUserDTO customerDTO)
        {
            Customer customer = null;
            User user = null;
            try
            {
                customer = customerDTO;
                user = MapCustomerUserDTOToUser(customerDTO);
                customer = await _customerRepo.Add(customer);
                user.CustomerId = customer.Id;
                user = await _userRepo.Add(user);
                ((CustomerUserDTO)customer).Password = string.Empty;
                return customer;
            }
            catch (Exception) { }
            if (customer != null)
                await RevertCustomerInsert(customer);
            if (user != null && customer == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.CustomerId);
        }

        private async Task RevertCustomerInsert(Customer customer)
        {
            await _customerRepo.Delete(customer.Id);
        }

        private User MapCustomerUserDTOToUser(CustomerUserDTO customerDTO)
        {
            User user = new User();
            user.CustomerId = customerDTO.Id;
            user.Status = "Active";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customerDTO.Password));
            return user;
        }
    }


}
