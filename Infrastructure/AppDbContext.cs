using Microsoft.EntityFrameworkCore;
using CleanProductApp.Domain.Entities;

namespace CleanProductApp.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<User> Users { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}