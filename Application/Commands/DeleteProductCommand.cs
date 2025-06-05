using MediatR;
using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.DTOs;

namespace CleanProductApp.Application.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<OperationResult>;
}