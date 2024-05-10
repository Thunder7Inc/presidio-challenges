using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrakerModelLibrary;


namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        readonly Dictionary<int, Request> _requestRepository;
        public RequestRepository()
        {
            _requestRepository = new Dictionary<int, Request>();
        }
        int GenerateId()
        {
            if (_requestRepository.Count == 0)
                return 1001;
            int id = _requestRepository.Keys.Max();
            return ++id;
        }

        public Request Add(Request item)
        {
            if (_requestRepository.ContainsValue(item))
            {
                throw new DuplicateRequestException();
            }
            item.Id = GenerateId();
            _requestRepository.Add(item.Id, item);
            return item;
        }
        public Request Remove(int id)
        {
            if (_requestRepository.ContainsKey(id))
            {
                var request = _requestRepository[id];
                _requestRepository.Remove(id);
                return request;
            }
            throw new RequestIDNotFoundException();
        }

        public Request Get(int id)
        {
            return _requestRepository[id] ?? throw new RequestIDNotFoundException();
        }
        public List<Request> GetAll()
        {
            if (_requestRepository.Count == 0)
                throw new EmptyDBException();
            return _requestRepository.Values.ToList();
        }

        public Request Update(Request item)
        {
            if (_requestRepository.ContainsKey(item.Id))
            {
                _requestRepository[item.Id] = item;
                return item;
            }
            throw new RequestIDNotFoundException();
        }

        public Request Delete(int id)
        {
            if (_requestRepository.ContainsKey(id))
            {
                var request = _requestRepository[id];
                _requestRepository.Remove(id);
                return request;
            }
            throw new RequestIDNotFoundException();
        }
    }
}
