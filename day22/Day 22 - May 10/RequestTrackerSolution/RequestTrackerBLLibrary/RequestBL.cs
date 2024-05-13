using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int, Request> _requestRepository;

        public RequestBL(IRepository<int, Request> requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Request> AddRequest(Request request)
        {
            return await _requestRepository.Add(request);
        }

        public async Task<Request> UpdateRequest(Request request, string requestStatus)
        {
            request.RequestStatus = requestStatus;
            return await _requestRepository.Update(request);
        }

        public async Task<Request> GetRequest(int requestNumber)
        {
            return await _requestRepository.Get(requestNumber);
        }

        public async Task<IList<Request>> GetAllRequests()
        {
            return await _requestRepository.GetAll();
        }

        public async Task<IList<Request>> GetRequestwithID(int requestRaisedBy)
        {
            var res = (await _requestRepository.GetAll()).ToList().FindAll(
                r => r.RequestRaisedBy == requestRaisedBy);
            return res;
        }

        
    }
}
