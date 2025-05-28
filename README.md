# CleanProductApp

**CleanProductApp** is a demo .NET project following **Clean Architecture** principles, utilizing **Entity Framework Core**, **CQRS with MediatR**, and an **ASP.NET Core Web API**.The application manages products by allowing them to be added and retrieved from a SQL Server database.

## ✨ Features

- Retrieve all products via REST API (using Pagination)
- Add new Product
- Implements CQRS (Command Query Responsibility Segregation)
- Fully separated architecture (Domain, Application, Infrastructure, WebAPI)
- Uses `MediatR` for decoupled request/response handling

---


## 📁 Project Structure

# CleanProductApp - Directory Structure

```
CleanProductApp/
├── Application/
│   ├── Commands/          # AddProductCommand
│   ├── Queries/          # GetAllProductsQuery
│   ├── Handlers/         # Handlers for CQRS
│   └── Interfaces/       # IProductRepository
├── Domain/
│   └── Entities/         # Product.cs
├── Infrastructure/
│   ├── Repositories/     # ProductRepository
│   └── AppDbContext.cs
├── WebAPI/
│   └── Controllers/      # ProductsController
├── Program.cs
└── appsettings.json
```
## 🛠️ Technologies Used

- **.NET 8**
- **Entity Framework Core**
- **MediatR**
- **ASP.NET Core Web API**
- **SQL Server**

## 🚀 Upcoming Features & Improvements

- 🔐 **JWT Authentication** — Secure the API with token-based authentication.
- 🗑️ **Delete Product Endpoint** — Allow deletion of products via HTTP DELETE requests.
- ♻️ **Update Product Endpoint** — Enable editing/updating product data.
- 🧪 **Unit & Integration Tests** — Improve test coverage for handlers and controllers.
- 📘 **Swagger/OpenAPI Documentation** — Auto-generate interactive API docs.
