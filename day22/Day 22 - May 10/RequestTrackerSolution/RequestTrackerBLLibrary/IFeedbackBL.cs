using RequestTrackerModelLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IFeedbackBL
    {
        Task<SolutionFeedback> AddFeedback(SolutionFeedback feedback);
        Task<SolutionFeedback> GetFeedback(int feedbackId);
        Task<IList<SolutionFeedback>> GetAllFeedbacks();
    }
}
