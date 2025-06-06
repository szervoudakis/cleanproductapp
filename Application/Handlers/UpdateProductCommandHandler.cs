using MediatR;
using CleanProductApp.Application.Interfaces; 
using CleanProductApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Commands;
using CleanProductApp.Application.DTOs;

namespace CleanProductApp.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, OperationResult>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<OperationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
                return OperationResult.Failure("The product not found in db!");

            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;

            await _productRepository.UpdateAsync(existingProduct);
            return OperationResult.Success(
                "Product updated suscessfully", 
                existingProduct 
            );
        }
    }
}