using EmployeeRequestTrackerApp.Contexts.cs;
using EmployeeRequestTrackerApp.Interfaces;
using EmployeeRequestTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerApp.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        #region Context Object 
        private RequestTrackerContext _context;
        public UserRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        #endregion

        #region Add User
        public async Task<User> Add(User item)
        {
            item.Status = "Disabled";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        #endregion

        #region Delete User
        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
        #endregion

        #region GetByKey 
        public async Task<User> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmployeeId == key);
            return user;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<User>> Get()
        {
            return (await _context.Users.ToListAsync());
        }
        #endregion

        #region Update
        public async Task<User> Update(User item)
        {
            var user = await Get(item.EmployeeId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("No user with the given ID");
        }
        #endregion
    }
}
