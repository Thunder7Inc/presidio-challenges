using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.interfaces;
using PizzaShopAPI.models;

namespace PizzaShopAPI.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizzas();
                return Ok(pizzas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Instock")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizzasInStock()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizzasInStock();
                return Ok(pizzas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}

    
