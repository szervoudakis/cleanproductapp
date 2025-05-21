using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Commands;

namespace CleanProductApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  //defines the base route for this controller
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]                  //defines an HTTP GET endpoint to retrieve all products
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]  //defines an HTTP POST endpoint to add product in db
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllProducts), new { id = productId }, new { id = productId });    
        }
    }
}
