using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrakerModelLibrary;
using RequestTrackerDALLibrary;

namespace RequestTrackerBLLibrary
{
    public class RequestBL
    {
        readonly IRepository<int, Request> _repository;
        public RequestBL()
        {
            _repository = new RequestRepository();
        }

        public Request AddRequest()
        {
            try
            {
                Request request = new Request();
                request.BuildRequest();
                return _repository.Add(request);
            }
            catch (DuplicateRequestException)
            {
                throw new DuplicateRequestException();
            }
        }

        public List<Request> GetAllRequests()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDBException)
            {
                throw new EmptyDBException();
            }
        }
        public Request GetRequest()
        {
            try
            {
                int id = Request.GetRequestIdFromConsole();
                return _repository.Get(id);
            }
            catch (RequestIDNotFoundException)
            {
                throw new RequestIDNotFoundException();
            }
        }

        public Request RemoveRequest()
        {
            try
            {
                int id = Request.GetRequestIdFromConsole();
                return _repository.Delete(id);
            }
            catch (RequestIDNotFoundException)
            {
                throw new RequestIDNotFoundException();
            }
        }
        public Request CloseRequest()
        {
            try
            {
                int id = Request.GetRequestIdFromConsole();
                int e_id = Request.ClosedByFromConsole();
                Request request = _repository.Get(id);
                request.Closed_By = e_id;
                return _repository.Update(request);
            }
            catch (RequestIDNotFoundException)
            {
                throw new RequestIDNotFoundException();
            }
        }
    }
}
