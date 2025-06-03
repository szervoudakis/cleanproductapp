using MediatR;
using CleanProductApp.Application.Interfaces; 
using CleanProductApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanProductApp.Application.Queries;

namespace CleanProductApp.Application.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
     private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdAsync(request.Id); 
    }
}
