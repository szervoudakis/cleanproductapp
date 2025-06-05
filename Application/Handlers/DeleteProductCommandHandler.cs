using MediatR;
using CleanProductApp.Application.Interfaces; 
using CleanProductApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanProductApp.Application.Queries;
using CleanProductApp.Application.Commands;
using CleanProductApp.Application.DTOs;

namespace CleanProductApp.Application.Handlers;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, OperationResult> 
{
   
    private readonly IProductRepository _repository;
    
    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    } 
    public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null)
            return OperationResult.Failure("The product not found");

        await _repository.DeleteAsync(product);
        return OperationResult.Success("The product successfully deleted.");
    }
}

