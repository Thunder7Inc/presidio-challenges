using EmployeeRequestTrackerApp.Interfaces;
using EmployeeRequestTrackerApp.Models.DTOs;
using EmployeeRequestTrackerApp.Models;
using System.Security.Cryptography;
using System.Text;
using EmployeeRequestTrackerApp.Exceptions;

namespace EmployeeRequestTrackerApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            //initialize HMACSHA512 with Key 
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            // Hash the User given password 
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            //compare the hashed password with the password saved in the database
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            // if they are same get the employee
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.Get(loginDTO.UserId);
                if (userDB.Status == "Active")
                {
                    LoginReturnDTO loginReturnDTO = MapEmploeeToLoginReturn(employee);
                    return loginReturnDTO;
                }
                throw new Exception("Your account is not activated");
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

        public async Task<Employee> Register(EmployeeUserDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                // copy all to employee
                employee = employeeDTO;
                // map to user 
                user = MapEmployeeUserDTOToUser(employeeDTO);
                employee = await _employeeRepo.Add(employee);
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);
                ((EmployeeUserDTO)employee).Password = string.Empty;
                return employee;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapEmploeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeId = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {
            await _employeeRepo.Delete(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(EmployeeUserDTO employeeDTO)
        {
            User user = new User();
            user.EmployeeId = employeeDTO.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }

        public async Task<ActivateUserReturnDTO> ActivateUserById(ActivateUserDTO activateUserDTO)
        {
            var user = await _userRepo.Get(activateUserDTO.EmployeeId);
            if (user == null)
            {
                throw new Exception("User Not Found With given Id");
            }
            user.Status = "Active";
            var updatedUser = await _userRepo.Update(user);
            if(updatedUser.Status=="Active")
            {
                ActivateUserReturnDTO returnDTO = MapActivateUserReturnTOUpdatedUser(updatedUser);
                return returnDTO;
            }
            throw new Exception("Unable to Update Status");
        }

        private ActivateUserReturnDTO MapActivateUserReturnTOUpdatedUser(User updatedUser)
        {
            ActivateUserReturnDTO returnDTO=new ActivateUserReturnDTO();
            returnDTO.EmployeeId=updatedUser.EmployeeId;
            returnDTO.Status = updatedUser.Status;
            return returnDTO;
        }
    }
}
