using EmployeeRequestTrackerApp.Interfaces;
using EmployeeRequestTrackerApp.Models;
using EmployeeRequestTrackerApp.Models.DTOs;
using EmployeeRequestTrackerApp.Repositories;
using System.Collections.Generic;

namespace EmployeeRequestTrackerApp.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, Employee> _employeeRepository;
        public RequestService(IRepository<int,Request> reposiroty , IRepository<int,Employee> employee)
        {
            _requestRepository = reposiroty;
            _employeeRepository = employee;
        }
        public async Task<RequestReturnDTO> AddRequest(AddRequestDTO addRequestDTO)
        {
            Employee employee = await _employeeRepository.Get(addRequestDTO.EmployeeId);
            if (employee != null)
            {
                Request request = new Request(addRequestDTO.RequestMessage, addRequestDTO.EmployeeId);
                await _requestRepository.Add(request);
                RequestReturnDTO returnDTO = MapRequestReturnToRequest(request);
                return returnDTO;
            }
            throw new Exception("No such employee with given Id");
        }

        private RequestReturnDTO MapRequestReturnToRequest(Request request)
        {
            RequestReturnDTO returnDTO=new RequestReturnDTO();
            returnDTO.RequestNumber=request.RequestNumber;
            returnDTO.RequestMessage=request.RequestMessage;
            returnDTO.RequestDate=request.RequestDate;
            returnDTO.RequestStatus=request.RequestStatus;
            returnDTO.ClosedDate=request.ClosedDate;
            return returnDTO;
        }

        public async Task<List<RequestReturnDTO>> GetAllOpenEmployeesRequestByAdmin()
        {
            try
            {
                var requests = await _requestRepository.Get();
                if (requests.Count()<=0)
                {
                    throw new Exception("Request Not Found");
                }
                var openRequests =requests.Where(e => e.RequestStatus == "Open").ToList();
                List<RequestReturnDTO> returnList = new List<RequestReturnDTO>();
                foreach (var request in requests)
                {
                    returnList.Add(MapRequestReturnToRequest(request));
                }
                return returnList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting data" + ex.Message);
            }
        }

        public async Task<List<RequestReturnDTO>> GetAllRequestForEmployeeById(int employeeId)
        {
            try
            {
                var requests = await _requestRepository.Get();
                var allRequest=  requests.Where(e => e.RequestRaisedBy == employeeId).ToList();
                if (allRequest.Count <= 0)
                {
                    throw new Exception("No Request Present");
                }
                List <RequestReturnDTO> returnList = new List <RequestReturnDTO>();
                foreach (var request in allRequest)
                {
                    returnList.Add(MapRequestReturnToRequest(request));
                }
                return returnList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
