using CleanProductApp.Domain.Entities;

namespace CleanProductApp.Application.Interfaces;
// Interface for product repository with asynchronous methods for adding and retrieving products
public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}
