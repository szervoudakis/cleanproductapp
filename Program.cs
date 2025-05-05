using CleanProductApp.Infrastructure;
using CleanProductApp.Domain.Entities;
using CleanProductApp.Infrastrucure;

var db = new AppDbContext();
var repo = new ProductRepository(db);

//repo.Add(new Product { Name = "Laptop", Price = 999.99m });

var products = repo.GetAll();

foreach (var product in products)
{
    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
}
