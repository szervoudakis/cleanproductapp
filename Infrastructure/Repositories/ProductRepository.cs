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
    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product); // Adds the product to the DbSet
        await _context.SaveChangesAsync();   // Saves changes to the database 

        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync(); // Fetches all products as a list
    }

    public async Task<Product?> GetByIdAsync(int id) //retrieve specific product by id
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
