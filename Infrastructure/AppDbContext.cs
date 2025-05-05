using Microsoft.EntityFrameworkCore;
using CleanProductApp.Domain.Entities;

namespace CleanProductApp.Infrastrucure;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=STEFZER\\SQLEXPRESS;Database=Products;Trusted_Connection=True;Encrypt=False;");
    }
}