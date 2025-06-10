# CleanProductApp

**CleanProductApp** is a demo .NET project following **Clean Architecture** principles, utilizing **Entity Framework Core**, **CQRS with MediatR**, and an **ASP.NET Core Web API**.The application manages products by allowing them to be added and retrieved from a SQL Server database.

## ✨ Features

- Retrieve all products via REST API (using Pagination) (GET Request)
- Add new Product (POST Request)
- Update Product (PUT Request)
- Delete Product (Delete Request)
- Implements CQRS (Command Query Responsibility Segregation)
- Fully separated architecture (Domain, Application, Infrastructure, WebAPI)
- Uses `MediatR` for decoupled request/response handling
- Secure private endpoints using authentication middleware (JWT Bearer authentication)

---


## 📁 Project Structure

# CleanProductApp - Directory Structure

```
CleanProductApp/
├── Application/
│   ├── Commands/         # AddProductCommand
│   ├── Queries/          # GetAllProductsQuery
│   ├── Handlers/         # Handlers for CQRS
│   └── Interfaces/       # IProductRepository
    └── DTOs/             # object for Success/Failure messages 
├── Domain/
│   └── Entities/         # Product.cs
├── Infrastructure/
│   ├── Repositories/     # ProductRepository
│   └── AppDbContext.cs
├── WebAPI/
│   └── Controllers/      # ProductsController
    └── Models/           # RegisterRequest
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
- 🧪 **Unit & Integration Tests** — Improve test coverage for handlers and controllers.
- 📘 **Swagger/OpenAPI Documentation** — Auto-generate interactive API docs.
- **Validation Handling** - 
