using EmployeeRequestTrackerApp.Models.DTOs;

namespace EmployeeRequestTrackerApp.Interfaces
{
    public interface IRequestService
    {
        //int EmployeeId, string RequestMessage
        public Task<RequestReturnDTO> AddRequest(AddRequestDTO addRequestDTO);
        public Task<List<RequestReturnDTO>> GetAllRequestForEmployeeById(int employeeId);
        public Task<List<RequestReturnDTO>> GetAllOpenEmployeesRequestByAdmin();
    }
}
