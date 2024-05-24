using EmployeeRequestTrackerApp.Models;

namespace EmployeeRequestTrackerApp.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Employee employee);
    }
}
