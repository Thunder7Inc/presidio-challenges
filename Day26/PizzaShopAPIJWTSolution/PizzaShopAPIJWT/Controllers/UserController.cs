using Microsoft.AspNetCore.Mvc;
using PizzaShopAPIJWT.interfaces;
using PizzaShopAPIJWT.model.DTOs;
using PizzaShopAPIJWT.model;
using PizzaShopAPIJWT.services;

namespace PizzaShopAPIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Customer>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (UnauthorizedUserException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Customer>> Register(CustomerUserDTO userDTO)
        {
            try
            {
                Customer result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (UnableToRegisterException ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
