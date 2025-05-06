using CleanProductApp.Domain.Entities;

namespace CleanProductApp.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<IEnumerable<Product>> GetAllAsync();
}
