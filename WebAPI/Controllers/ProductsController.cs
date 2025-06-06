using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Commands;
using CleanProductApp.Application.Models;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]//defines an HTTP GET endpoint to retrieve all products
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllProductsQuery(pageNumber, pageSize);
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [Authorize]
        [HttpPost]  //defines an HTTP POST endpoint to add product in db
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await _mediator.Send(command);
            //return json with id,name,price of created product
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpGet("{id}")]    //defines http get endpoint to retrieve specific product by id
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id; //we want the id to pass from route
            var result = await _mediator.Send(command);

             return result.IsSuccess ? Ok(result) : NotFound(result); 
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            return result.IsSuccess ? Ok(result) : NotFound(result);
        }
    }
}
