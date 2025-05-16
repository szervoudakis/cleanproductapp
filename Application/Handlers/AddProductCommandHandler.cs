using MediatR;
using CleanProductApp.Application.Interfaces;
using CleanProductApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using CleanProductApp.Application.Commands;

namespace CleanProductApp.Application.Handlers
{
     public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await _productRepository.AddAsync(product);
            return product.Id; 
        }
    }
}
