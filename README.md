# CarCare

An ASP.NET Core web API for managing car care services.

## Introduction

CarCare is a comprehensive solution for managing car care services, including customer information, orders, products, and suppliers. This API provides a set of endpoints to interact with the CarCare system.

## Features

*   **Authentication and Authorization:** Secure endpoints using JWT.
*   **Customer Management:** CRUD operations for customers.
*   **Order Management:** Create, read, update, and delete orders.
*   **Product Management:** Manage product inventory.
*   **Supplier Management:** Handle supplier information.

## Technologies Used

*   ASP.NET Core 8
*   Entity Framework Core 8
*   Swagger/OpenAPI
*   AutoMapper
*   Microsoft SQL Server

## Project Structure

The solution is divided into the following projects:

*   `CarCare.Api`: The main API project, containing controllers, services, and DTOs.
*   `CarCare.BLL`: Business Logic Layer (currently minimal).
*   `CarCare.DAL`: Data Access Layer, responsible for database interactions using Entity Framework Core.
*   `CarCare.Domain`: Core domain entities and repository interfaces.
*   `CarCare.Infrastructure`: Infrastructure concerns like email services and identity management.

## Getting Started

### Prerequisites

*   .NET 8 SDK
*   Microsoft SQL Server

### Installation

1.  Clone the repository:
    ```bash
    git clone https://github.com/your-username/CarCare.git
    ```
2.  Navigate to the project directory:
    ```bash
    cd CarCare
    ```
3.  Configure the database connection string in `CarCare.Api/appsettings.json`.
4.  Apply database migrations:
    ```bash
    dotnet ef database update --project CarCare.DAL
    ```
5.  Run the application:
    ```bash
    dotnet run --project CarCare.Api
    ```

The API will be available at `https://localhost:5001`. You can access the Swagger UI at `https://localhost:5001/swagger`.

## API Endpoints

The following are the main API endpoints:

*   **Auth:**
    *   `POST /api/Auth/register`
    *   `POST /api/Auth/login`
*   **Customer:**
    *   `GET /api/Customer`
    *   `GET /api/Customer/{id}`
    *   `POST /api/Customer`
    *   `PUT /api/Customer/{id}`
    *   `DELETE /api/Customer/{id}`
*   **Order:**
    *   `GET /api/Order`
    *   `GET /api/Order/{id}`
    *   `POST /api/Order`
    *   `PUT /api/Order/{id}`
    *   `DELETE /api/Order/{id}`
*   **Product:**
    *   `GET /api/Product`
    *   `GET /api/Product/{id}`
    *   `POST /api/Product`
    *   `PUT /api/Product/{id}`
    *   `DELETE /api/Product/{id}`
*   **Supplier:**
    *   `GET /api/Supplier`
    *   `GET /api/Supplier/{id}`
    *   `POST /api/Supplier`
    *   `PUT /api/Supplier/{id}`
    *   `DELETE /api/Supplier/{id}`

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## License

This project is licensed under the MIT License.
