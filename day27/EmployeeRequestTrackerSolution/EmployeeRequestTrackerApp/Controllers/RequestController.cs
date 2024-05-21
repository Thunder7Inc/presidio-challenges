using EmployeeRequestTrackerApp.Exceptions;
using EmployeeRequestTrackerApp.Interfaces;
using EmployeeRequestTrackerApp.Models;
using EmployeeRequestTrackerApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController:ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [Authorize]
        [HttpPost("AddRequest")]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RequestReturnDTO>> AddReq(AddRequestDTO addRequestDTO)
        {
            try
            {
                var result =await  _requestService.AddRequest(addRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("GetAllRequestsOfEmployees")]
        [ProducesResponseType(typeof(List<RequestReturnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<RequestReturnDTO>>> GetAllReq()
        {
            try
            {
                var requests = await _requestService.GetAllOpenEmployeesRequestByAdmin();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        [Authorize]
        [HttpPost("GetAllRequestForEmployee")]
        [ProducesResponseType(typeof(List<RequestReturnDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<RequestReturnDTO>>> GetAllReqForEmployee([FromBody] int employeeId)
        {
            try
            {
                var requests = await _requestService.GetAllRequestForEmployeeById(employeeId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

    }
}
