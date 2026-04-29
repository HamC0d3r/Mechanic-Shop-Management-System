# Mechanic Shop Management System

A modern, full-stack web application for managing mechanic shop operations, built with **Blazor WebAssembly** and ASP.NET Core. This system streamlines work orders, billing, customer management, real-time updates, and more.

## Features

- **Work Order Management:** Create, update, schedule, and track work orders.
- **Customer & Vehicle Management:** Manage customer profiles and their vehicles.
- **Billing & Invoicing:** Issue invoices, view invoice details, and download PDFs.
- **Real-Time Updates:** Live work order status via SignalR.
- **Role-Based Access:** Secure endpoints and UI with authentication and authorization.
- **Dashboard & Reporting:** View daily stats and shop performance.

## Tech Stack

- **Backend:** ASP.NET Core Web API (.NET )
- **Database:** Entity Framework Core (SQL Server)
- **Authentication:** JWT Bearer, ASP.NET Core Identity
- **Real-Time:** SignalR
- **Logging:** Serilog
- **Patterns:** Dependency injection, CQRS Pattern, Result Pattern 
## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 
- [Visual Studio 2022](https://visualstudio.microsoft.com/)

### Setup Instructions

1. **Clone the repository:**

2. **Configure the database:**
   - Update the connection string in `appsettings.json` (in the API project) to point to your SQL Server instance.

3. **Apply database migrations:**

4. **Run the solution:**
- Open in Visual Studio 2022 and set `MechanicShop.Api` as the startup project.
- Press F5 to build and run both the API and Blazor client.

5. **Access the app:**
- Navigate to `https://localhost:5001` (or the port shown in the console).

### API Documentation

- Swagger UI is available in development mode at `/swagger`.

## Project Structure

- `MechanicShop.Api` - ASP.NET Core Web API (backend)
- `MechanicShop.Infrastructure` - Data access, EF Core, and integrations
- `MechanicShop.Domain` - Core business logic and models
- `MechanicShop.Application` - Application services and CQRS handlers

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements or bug fixes.

## License

This project is licensed under the MIT License.

---

