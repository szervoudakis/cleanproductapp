using CleanProductApp.Domain.Entities;

namespace CleanProductApp.Application.Interfaces;

public interface IProductRepository
{
    void Add(Product product);
    IEnumerable<Product> GetAll();
}
