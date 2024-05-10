using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL
    {
        private readonly IRepository<int, Request> _repository;
        public RequestBL()
        {
            IRepository<int, Request> repo = new RequestRepositry(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<Request> Add(int empID,string msg)
        {
            Request request = new Request() { RequestRaisedBy = empID, RequestMessage = msg };
            var result = await _repository.Add(request);

            return result;
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _repository.GetAll();
        }
        
    }
}
