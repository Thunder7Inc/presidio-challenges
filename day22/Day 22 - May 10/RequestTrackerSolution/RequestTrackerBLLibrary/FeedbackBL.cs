using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IRepository<int, SolutionFeedback> _feedbackRepository;

        public FeedbackBL(IRepository<int, SolutionFeedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<SolutionFeedback> AddFeedback(SolutionFeedback feedback)
        {
            return await _feedbackRepository.Add(feedback);
        }

        public async Task<SolutionFeedback> GetFeedback(int feedbackId)
        {
            return await _feedbackRepository.Get(feedbackId);
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedbacks()
        {
            return await _feedbackRepository.GetAll();
        }
    }
}
