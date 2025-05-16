using MediatR;
using CleanProductApp.Domain.Entities;

namespace CleanProductApp.Application.Commands
{
    public class AddProductCommand : IRequest<int> // the answer will be the id of product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
  
        public AddProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
