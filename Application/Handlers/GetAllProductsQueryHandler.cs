using MediatR;
using CleanProductApp.Application.Interfaces;
using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Models;
using Microsoft.EntityFrameworkCore;
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
            
            var query = _productRepository.GetAll();  //take all product as queryable 
            var totalCount = await query.CountAsync(); //execute with async the Count in db

            var pagedItems = await query
                .Skip((request.PageNumber - 1) * request.PageSize) //skip the items from previous pages  
                .Take(request.PageSize)  //take only the items for the current page
                .ToListAsync();//convert the result to a list (async)

            return new PaginatedResult<Product>(pagedItems, totalCount, request.PageNumber, request.PageSize);
        }
    }
}
