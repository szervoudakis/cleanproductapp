using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.Interfaces;
using CleanProductApp.Infrastructure;
using CleanProductApp.Infrastrucure;

namespace CleanProductApp.Infrastructure;

public class ProductRepository : IProductRepository
{
   // private readonly AppDbContext _context;
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}
