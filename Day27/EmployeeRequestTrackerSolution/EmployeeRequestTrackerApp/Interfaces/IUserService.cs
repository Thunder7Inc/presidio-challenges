using EmployeeRequestTrackerApp.Models.DTOs;
using EmployeeRequestTrackerApp.Models;

namespace EmployeeRequestTrackerApp.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
        public Task<ActivateUserReturnDTO> ActivateUserById(ActivateUserDTO activateUserDTO);
    }
}
