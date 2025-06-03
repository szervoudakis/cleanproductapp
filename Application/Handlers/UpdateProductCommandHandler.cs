using MediatR;
using CleanProductApp.Application.Interfaces; 
using CleanProductApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Commands;

namespace CleanProductApp.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;

            await _productRepository.UpdateAsync(existingProduct);
            return true;
        }
    }
}