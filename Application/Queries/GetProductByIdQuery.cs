using MediatR;
using CleanProductApp.Domain.Entities;
using System.Collections.Generic;
using CleanProductApp.Application.Models;

namespace CleanProductApp.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product?>;
}