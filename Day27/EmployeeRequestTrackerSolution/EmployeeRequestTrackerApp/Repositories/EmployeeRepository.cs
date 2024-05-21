using EmployeeRequestTrackerApp.Contexts.cs;
using EmployeeRequestTrackerApp.Exceptions;
using EmployeeRequestTrackerApp.Interfaces;
using EmployeeRequestTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerApp.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchEmployeeException();
        }

        public async Task<Employee> Get(int key)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;

        }

        public async Task<Employee> Update(Employee item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchEmployeeException();
        }
    }
}
