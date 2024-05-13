using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        private readonly RequestTrackerContext _context;

        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            var solutionFeedback = await _context.SolutionFeedbacks.FindAsync(key);
            if (solutionFeedback != null)
            {
                _context.SolutionFeedbacks.Remove(solutionFeedback);
                await _context.SaveChangesAsync();
            }
            return solutionFeedback;
        }

        public async Task<SolutionFeedback> Get(int key)
        {
            return await _context.SolutionFeedbacks.FindAsync(key);
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.SolutionFeedbacks.ToListAsync();
        }
    }
}
