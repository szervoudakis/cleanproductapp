using MediatR;
using CleanProductApp.Application.Interfaces;
using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

//this handler implements the MediatR pattern
//it takes one GetAllProductsQuery and returns one list with products
namespace CleanProductApp.Application.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
