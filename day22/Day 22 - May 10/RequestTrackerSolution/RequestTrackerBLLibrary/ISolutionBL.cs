using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionBL
    {
        Task<RequestSolution> AddSolution(RequestSolution solution);
        Task<RequestSolution> GetSolution(int solutionId);
        Task<IList<RequestSolution>> GetAllSolutions();
        Task<RequestSolution> UpdateSolution(RequestSolution solution);
    }
}
