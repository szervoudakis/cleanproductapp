using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanProductApp.Application.Queries;

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
    }
}
