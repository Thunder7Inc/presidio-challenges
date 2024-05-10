using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrakerModelLibrary;
using RequestTrackerDALLibrary;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL
    {
        readonly IRepository<int, Employee> _repository;
        public EmployeeBL()
        {
            _repository = new EmployeeRepository();
        }

        public Employee AddEmployee()
        {
            try
            {
                Employee employee = new Employee();
                employee.BuildEmployee();
                return _repository.Add(employee);
            }
            catch (DuplicateEmployeeDetailsException)
            {
                throw new DuplicateEmployeeDetailsException();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDBException)
            {
                throw new EmptyDBException();
            }
        }
        public Employee GetEmployee()
        {
            try
            {
                int id = Employee.GetEmployeeIdFromConsole();
                return _repository.Get(id);
            }
            catch (EmployeeNotFoundException)
            {
                throw new EmployeeNotFoundException();
            }
        }

        public Employee RemoveEmployee()
        {
            try
            {
                int id = Employee.GetEmployeeIdFromConsole();
                return _repository.Delete(id);
            }
            catch (EmployeeNotFoundException)
            {
                throw new EmployeeNotFoundException();
            }
        }
        public Employee UpdateEmployee()
        {
            try
            {
                Employee employee = new Employee();
                employee.BuildEmployee();
                return _repository.Update(employee);
            }
            catch (EmployeeNotFoundException)
            {
                throw new EmployeeNotFoundException();
            }
        }
       

    }
}
