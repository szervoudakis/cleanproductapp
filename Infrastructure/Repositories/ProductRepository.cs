using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.Interfaces;
using CleanProductApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanProductApp.Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
   
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
