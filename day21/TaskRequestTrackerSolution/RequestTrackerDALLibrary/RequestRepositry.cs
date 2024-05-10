using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepositry : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;
        public RequestRepositry(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<Request> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Request> Get(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public Task<Request> Update(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
