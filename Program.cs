using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CleanProductApp.Infrastructure;
using CleanProductApp.Domain.Entities;
using CleanProductApp.Application.Interfaces;

// Build and configure the Host with dependency injection and configuration services
var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        // Load configuration from appsettings.json
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Retrieve connection string from configuration
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        // Register the DbContext with SQL Server provider
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Register the repository as a scoped service
        services.AddScoped<IProductRepository, ProductRepository>();
    })
    .Build();

// Create a scope for resolving scoped services
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

// Get the repository from the service provider
var repo = services.GetRequiredService<IProductRepository>();

// Optional: Add a new product to the database
// await repo.AddAsync(new Product { Name = "Laptop", Price = 999.99m });

// Retrieve all products asynchronously
var products = await repo.GetAllAsync();

// Print all products to the console
foreach (var product in products){
    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
}
