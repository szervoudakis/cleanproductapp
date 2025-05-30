using MediatR;
using CleanProductApp.Domain.Entities;
using System.Collections.Generic;
using CleanProductApp.Application.Models;

namespace CleanProductApp.Application.Queries
{
    public class GetAllProductsQuery : IRequest<PaginatedResult<Product>>
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        //query to retrieve a paginated list of Product data  (MediatR)
        public GetAllProductsQuery(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
  
}
