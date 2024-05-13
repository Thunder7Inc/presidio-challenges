using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;


namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Update(Request entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request?> Delete(int key)
        {
            var request = await _context.Requests.FindAsync(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<Request> Get(int key)
        {
            return await _context.Requests.FindAsync(key);
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }
    }
}
