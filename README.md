# CleanProductApp

This project is a simple .NET Console application that demonstrates the basic principles of Clean Architecture and Entity Framework Core (EF Core). The application manages products by allowing them to be added and retrieved from a SQL Server database.

## Project Structure

The project is organized into three main layers:

- **Domain**: Contains the business logic entities. In this case, we have the `Product` entity.
- **Application**: Contains interfaces for repositories, including `IProductRepository`.
- **Infrastructure**: Implements the database context and repository. The `AppDbContext` manages the connection to the database, while `ProductRepository` handles the interaction with the `Product` entity.

