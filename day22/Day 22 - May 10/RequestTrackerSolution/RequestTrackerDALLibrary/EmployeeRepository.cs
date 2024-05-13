using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;


namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await _context.Employees.FindAsync(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employee> Get(int key)
        {
            return await _context.Employees.FindAsync(key);
        }

        public async Task<IList<Employee?>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
