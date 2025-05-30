using MediatR;
using CleanProductApp.Application.Interfaces;
using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanProductApp.Application.Handlers
{
    /// <summary>
    /// Handler responsible for processing the GetAllProductsQuery with pagination.
    /// Returns a PaginatedResult<Product> containing the requested page of products.
    /// </summary>
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginatedResult<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginatedResult<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository.GetAllAsync(); //get all products from repository async

            var totalCount = allProducts.Count();
            var pagedItems = allProducts
                .Skip((request.PageNumber - 1) * request.PageSize) //skip the items from previous pages  
                .Take(request.PageSize)  //take only the items for the current page
                .ToList();//convert the result to a list

            return new PaginatedResult<Product>(pagedItems, totalCount, request.PageNumber, request.PageSize);
        }
    }
}
