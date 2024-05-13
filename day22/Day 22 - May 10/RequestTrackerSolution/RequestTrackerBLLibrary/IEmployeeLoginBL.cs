using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeLoginBL
    {
        Task<Employee> Login(Employee employee);
        Task<Employee> Register(Employee employee);
    }
}
