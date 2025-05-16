using MediatR;
using CleanProductApp.Domain.Entities;
using System.Collections.Generic;

namespace CleanProductApp.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }
}
