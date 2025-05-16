# CleanProductApp

**CleanProductApp** is a demo .NET project following **Clean Architecture** principles, utilizing **Entity Framework Core**, **CQRS with MediatR**, and an **ASP.NET Core Web API**.The application manages products by allowing them to be added and retrieved from a SQL Server database.

## ✨ Features

- Add products to a SQL Server database
- Retrieve all products via REST API
- Implements CQRS (Command Query Responsibility Segregation)
- Fully separated architecture (Domain, Application, Infrastructure, WebAPI)
- Uses `MediatR` for decoupled request/response handling

---


## 📁 Project Structure

CleanProductApp/
│
├── Application/
│ ├── Commands/ // AddProductCommand
│ ├── Queries/ // GetAllProductsQuery
│ ├── Handlers/ // Handlers for CQRS
│ ├── Interfaces/ // IProductRepository
│
├── Domain/
│ └── Entities/ // Product.cs
│
├── Infrastructure/
│ ├── Repositories/ // ProductRepository
│ └── AppDbContext.cs
│
├── WebAPI/
│ └── Controllers/ // ProductsController
│
├── Program.cs
└── appsettings.json 

## 🛠️ Technologies Used

- **.NET 8**
- **Entity Framework Core**
- **MediatR**
- **ASP.NET Core Web API**
- **SQL Server**