using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrakerModelLibrary;


namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {

        readonly Dictionary<int, Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new Dictionary<int, Employee>();
        }


        int GenerateId()
        {
            if (_employees.Count == 0)
                return 101;
            int id = _employees.Keys.Max();
            return ++id;
        }
        public Employee Add(Employee item)
        {
            if (_employees.ContainsValue(item))
            {
                throw new DuplicateEmployeeDetailsException();
            }
            item.Id = GenerateId();
            _employees.Add(item.Id, item);
            return item;
        }
        public Employee Get(int id)
        {
               return _employees[id] ?? throw new EmployeeNotFoundException();
        }

        public List<Employee> GetAll()
        {
            if (_employees.Count == 0)
                throw new EmptyDBException();
            return _employees.Values.ToList();
        }

        public Employee Update(Employee item)
        {
            if (_employees.ContainsKey(item.Id))
            {
                _employees[item.Id] = item;
                return item;
            }
            throw new EmployeeNotFoundException();
        }
        public Employee Delete(int key)
        {
            if (_employees.ContainsKey(key))
            {
                var employee = _employees[key];
                _employees.Remove(key);
                return employee;
            }
            throw new EmployeeNotFoundException();
        }

    }
}
