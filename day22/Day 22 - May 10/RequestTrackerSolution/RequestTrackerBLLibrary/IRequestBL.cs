using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        Task<Request> AddRequest(Request request);
        Task<Request> UpdateRequest(Request request, string requestStatus);
        Task<Request> GetRequest(int requestNumber);
        Task<IList<Request>> GetAllRequests();
        Task<IList<Request>> GetRequestwithID(int requestRaisedBy);
       
    }
}
