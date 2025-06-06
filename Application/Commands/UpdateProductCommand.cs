using CleanProductApp.Application.DTOs;
using MediatR;
using System;

namespace CleanProductApp.Application.Commands
{
    public class UpdateProductCommand : IRequest<OperationResult>
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

}