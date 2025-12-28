# 🔧 MechanicShop System

A modern, enterprise-grade **Automotive Repair Management System** built with cutting-edge .NET technologies. Streamline your mechanic shop operations with comprehensive work order management, customer tracking, employee scheduling, and real-time analytics.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Technology Stack](#technology-stack)
- [Project Architecture](#project-architecture)
- [Getting Started](#getting-started)
- [Development Setup](#development-setup)
- [Running the Application](#running-the-application)
- [Testing](#testing)
- [Project Structure](#project-structure)
- [API Documentation](#api-documentation)
- [Database](#database)
- [Monitoring & Observability](#monitoring--observability)
- [Contributing](#contributing)

---

## 🎯 Overview

**MechanicShop** is a comprehensive solution designed for automotive repair facilities to manage their day-to-day operations efficiently. The system provides:

- **Complete Work Order Lifecycle Management** - From creation to completion and invoicing
- **Customer & Vehicle Management** - Track customers, vehicles, and service history
- **Employee & Labor Tracking** - Manage employees, their tasks, and billable hours
- **Real-Time Communication** - Live updates using SignalR
- **Advanced Billing System** - Generate professional invoices with PDF export
- **Dashboard & Analytics** - Visual insights into shop performance and metrics
- **Role-Based Access Control** - Secure identity and authorization system
- **Modern UI** - Responsive Blazor WebAssembly frontend
- **Monitoring & Logging** - Production-ready observability with OpenTelemetry and Serilog

---

## ✨ Key Features

### 🛠️ Work Order Management
- Create and manage work orders with detailed repair descriptions
- Track repair task progress and completion status
- Assign tasks to employees with real-time updates
- Manage repair task history and documentation

### 👥 Customer Management
- Maintain comprehensive customer profiles
- Track customer vehicles and service history
- Store contact information and preferences
- View customer communication history

### 👨‍💼 Employee Management
- Employee profiles and role assignments
- Track labor hours and billable time
- Manage employee schedules
- Performance analytics and metrics

### 💳 Billing & Invoicing
- Automated invoice generation
- PDF invoice export with QuestPDF
- Labor cost calculation
- Payment tracking and history

### 📊 Dashboard & Reporting
- Real-time shop performance metrics
- Work order status overview
- Revenue tracking and analytics
- Employee productivity statistics

### 🔐 Security
- JWT token-based authentication
- Role-based authorization
- Secure API endpoints
- Identity management system

### 📡 Real-Time Updates
- SignalR integration for live notifications
- Instant work order status updates
- Real-time chat and communication
- Live dashboard refresh

### 📈 Observability
- OpenTelemetry instrumentation
- Structured logging with Serilog
- Prometheus metrics export
- Seq log aggregation and visualization

---

## 🏗️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 9.0 (latest)
- **Architecture**: Clean Architecture with CQRS pattern
- **ORM**: Entity Framework Core 9.0
- **API**: RESTful API with OpenAPI/Swagger documentation
- **Message Handler**: MediatR for command/query handling
- **Validation**: FluentValidation

### Frontend
- **Framework**: Blazor WebAssembly
- **State Management**: SignalR for real-time updates
- **Storage**: Blazored.LocalStorage
- **UI Components**: Responsive design with Razor Components
- **Authentication**: JWT with WebAssembly authentication

### Database
- **Primary**: Microsoft SQL Server 2022
- **Containerized**: Docker support for local development

### Monitoring & Logging
- **Logging**: Serilog with structured logging
- **APM**: OpenTelemetry with OTLP protocol
- **Visualization**: Seq for log aggregation and analysis
- **Metrics**: Prometheus metrics export
- **Distributed Tracing**: ASP.NET Core instrumentation

### Additional Libraries
- **PDF Generation**: QuestPDF (Community License)
- **Text Humanization**: Humanizer
- **API Documentation**: Scalar, Swashbuckle, Swagger
- **Rate Limiting**: Built-in ASP.NET Core rate limiting
- **Output Caching**: ASP.NET Core output caching
- **Code Analysis**: StyleCop Analyzers

### Development
- **.NET Version**: .NET 9.0
- **Language Features**: Nullable reference types, implicit usings, latest C# features
- **Testing Frameworks**: xUnit, Moq, Fluent Assertions
- **Build Tool**: dotnet CLI

---

## 🏛️ Project Architecture

This solution follows **Clean Architecture** principles with clear separation of concerns:

```
src/
├── MechanicShop.Api              # Presentation layer - API & Blazor Server
├── MechanicShop.Client           # Blazor WebAssembly frontend
├── MechanicShop.Application      # Business logic & use cases (CQRS)
├── MechanicShop.Domain           # Core domain models & entities
├── MechanicShop.Infrastructure   # Data access, EF Core, external services
└── MechanicShop.Contracts        # DTOs and API contracts

tests/
├── MechanicShop.Api.IntegrationTests           # API integration tests
├── MechanicShop.Application.SubcutaneousTests  # Application layer tests
├── MechanicShop.Application.UnitTests          # Unit tests for features
├── MechanicShop.Domain.UnitTests               # Domain model tests
└── MechanicShop.Tests.Common                   # Shared test utilities
```

### Layer Responsibilities

| Layer | Purpose |
|-------|---------|
| **Presentation (API)** | HTTP endpoints, middleware, authentication, real-time communication |
| **Client (Blazor)** | Interactive UI, client-side routing, local storage management |
| **Application** | CQRS commands & queries, business rules, validation, MediatR handlers |
| **Domain** | Entity definitions, value objects, domain logic, invariants |
| **Infrastructure** | Database context, repositories, external service integration |
| **Contracts** | Request/response DTOs for API communication |

---

## 🚀 Getting Started

### Prerequisites

- **.NET 9.0 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Visual Studio Code** or **Visual Studio 2022+**
- **Docker & Docker Compose** (for containerized development)
- **SQL Server 2022** (or use Docker)
- **Git**

### Quick Start (Docker)

The fastest way to get started is using Docker Compose:

```bash
# Clone the repository
git clone https://github.com/yourusername/mechanicshop.git
cd mechanicshop

# Start all services (API, SQL Server, Seq logging)
docker-compose up -d

# The application will be available at:
# API: http://localhost:5001
# Seq: http://localhost:8081
```

### Quick Start (Local Development)

```bash
# Restore dependencies
dotnet restore

# Update database
cd src/MechanicShop.Api
dotnet ef database update

# Run the API
dotnet run
```

---

## 💻 Development Setup

### Clone & Install

```bash
git clone <repository-url>
cd MechanicShop
dotnet restore
```

### Database Setup

#### Using Docker (Recommended)
```bash
# Start SQL Server container
docker-compose up sqlserver -d

# Connection string for local development:
# Server=localhost;Database=MechanicShopDb;User Id=sa;Password=YourStrong@Password1;TrustServerCertificate=True;
```

#### Using Local SQL Server
Update `appsettings.Development.json` with your connection string, then:

```bash
cd src/MechanicShop.Api
dotnet ef database update
```

### Environment Configuration

Create `src/MechanicShop.Api/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MechanicShopDb;User Id=sa;Password=YourStrong@Password1;TrustServerCertificate=True;"
  },
  "Serilog": {
    "MinimumLevel": "Debug"
  },
  "OTEL_EXPORTER_OTLP_ENDPOINT": "http://localhost:5341/ingest/otlp/v1/traces",
  "OTEL_EXPORTER_OTLP_PROTOCOL": "http/protobuf"
}
```

---

## ▶️ Running the Application

### Option 1: Using dotnet CLI

```bash
# Watch mode (auto-restart on code changes)
dotnet watch run --project src/MechanicShop.Api

# Standard run
cd src/MechanicShop.Api
dotnet run
```

### Option 2: Using VS Code Tasks

Available tasks in `tasks.json`:
- **build** - Build the solution
- **publish** - Publish for production
- **watch** - Watch mode with hot reload

```bash
# Run via task
Press Ctrl+Shift+D and select "watch"
```

### Option 3: Docker Compose (Full Stack)

```bash
# Start all services
docker-compose up -d

# View logs
docker-compose logs -f mechanicshop-api

# Stop services
docker-compose down
```

### Access Points

Once running, access the application at:

| Service | URL | Purpose |
|---------|-----|---------|
| **API** | http://localhost:5001 | REST API & Blazor frontend |
| **Swagger UI** | http://localhost:5001/swagger | API documentation |
| **Scalar Reference** | http://localhost:5001/scalar | Interactive API reference |
| **Seq** | http://localhost:8081 | Log aggregation & analysis |
| **SQL Server** | localhost:1433 | Database (with SA account) |

---

## 🧪 Testing

### Run All Tests

```bash
dotnet test

# With coverage report
dotnet test /p:CollectCoverage=true
```

### Run Specific Test Project

```bash
# Unit tests
dotnet test tests/MechanicShop.Domain.UnitTests

# Application tests
dotnet test tests/MechanicShop.Application.UnitTests

# Subcutaneous tests
dotnet test tests/MechanicShop.Application.SubcutaneousTests

# Integration tests
dotnet test tests/MechanicShop.Api.IntegrationTests
```

### Test Structure

- **Unit Tests**: Domain logic and application features
- **Subcutaneous Tests**: Application layer with in-memory database
- **Integration Tests**: Full API with real database
- **Common Test Utilities**: Shared fixtures, builders, and helpers

---

## 📁 Project Structure

### Core Projects

#### `MechanicShop.Domain`
Domain models and business logic:
- `Customers/` - Customer entities and value objects
- `Employees/` - Employee profiles and roles
- `WorkOrders/` - Work order aggregate root
- `RepairTasks/` - Task management and tracking
- `Identity/` - Authentication & authorization models
- `Common/` - Base entities, domain events

#### `MechanicShop.Application`
CQRS features and business rules:
- `Features/` - Organized by domain
  - `Customers/` - Commands & queries for customer operations
  - `WorkOrders/` - Work order management features
  - `RepairTasks/` - Task handling features
  - `Labors/` - Labor & billing features
  - `Billing/` - Invoice generation
  - `Dashboard/` - Analytics & reporting
  - `Scheduling/` - Employee scheduling
  - `Identity/` - Authentication features
- `Common/` - Validators, mappers, behaviors, exceptions

#### `MechanicShop.Infrastructure`
Data access and external services:
- `Data/` - Entity Framework Core DbContext & migrations
- `Identity/` - User management and JWT tokens
- `RealTime/` - SignalR hubs for live updates
- `BackgroundJobs/` - Scheduled tasks
- `Services/` - External integrations
- `Settings/` - Configuration models

#### `MechanicShop.Api`
API Layer - Controllers, endpoints, middleware:
- `Controllers/` - REST API endpoints
  - `CustomersController` - Customer operations
  - `WorkOrdersController` - Work order management
  - `RepairTasksController` - Task operations
  - `LaborsController` - Labor billing
  - `InvoicesController` - Invoice generation
  - `EmployeesController` - Employee management
  - `DashboardController` - Analytics
  - `IdentityController` - Auth endpoints
- `Endpoints/` - Minimal APIs
- `Components/` - Blazor components
- `Infrastructure/` - Middleware, filters, exception handling
- `Services/` - API-specific services
- `OpenApi/` - API documentation & schema transformers

#### `MechanicShop.Client`
Blazor WebAssembly frontend:
- `Pages/` - Main application pages
- `Components/` - Reusable Razor components
- `Services/` - HTTP client services, state management
- `Identity/` - Authentication handling
- `Models/` - Client-side models
- `Layout/` - App layout & navigation

#### `MechanicShop.Contracts`
API DTOs and contracts:
- `Requests/` - API request models
- `Responses/` - API response models
- `Common/` - Shared contract types

---

## 📡 API Documentation

### Swagger/OpenAPI

The API is fully documented with OpenAPI (Swagger):

```
Development: http://localhost:5001/swagger
Production: https://your-domain.com/swagger
```

Features:
- ✅ Try-it-out functionality
- ✅ Request/response examples
- ✅ Schema definitions
- ✅ Authentication integration

### Scalar Interactive Reference

Modern alternative to Swagger UI:

```
http://localhost:5001/scalar
```

### API Versioning

The API supports versioning through the `Asp.Versioning` package:

```
Header: api-version: 1.0
Query: ?api-version=1.0
```

---

## 🗄️ Database

### Schema Overview

Key entities and relationships:

```
Customers
├── Vehicles
└── WorkOrders
    ├── RepairTasks
    ├── Labors
    └── Invoices

Employees
├── Schedules
└── TaskAssignments
```

### Migrations

```bash
# Create new migration
cd src/MechanicShop.Api
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove

# View migration history
dotnet ef migrations list
```

### Seed Data

The database is automatically initialized with seed data on first run in development mode.

---

## 📊 Monitoring & Observability

### Serilog Logging

Structured logging with multiple sinks:

```csharp
Log.Information("Work order {WorkOrderId} created by {User}", orderId, user);
Log.Warning("Payment {PaymentId} delayed", paymentId);
Log.Error(ex, "Failed to process invoice {InvoiceId}", invoiceId);
```

### OpenTelemetry & Seq

Real-time log aggregation and analysis:

1. **Access Seq Dashboard**: http://localhost:8081
2. **Search logs** by level, date, properties
3. **Create signals** for alerts
4. **Analyze trends** and patterns

### Prometheus Metrics

Metrics are exported to Prometheus:

```
http://localhost:5001/metrics
```

Tracked metrics:
- HTTP request duration and count
- Database operation metrics
- Custom application metrics
- System performance

### Distributed Tracing

Full request tracing from client to database:

```json
{
  "traceId": "4bf92f3577b34da6a3ce929d0e0e4736",
  "spanId": "00f067aa0ba902b7",
  "parentSpanId": "123456789abcdef",
  "duration": 125.5
}
```

---

## 🤝 Contributing

### Coding Standards

- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use StyleCop for static analysis
- Write meaningful commit messages
- Add tests for new features
- Update documentation

### Pull Request Process

1. Create a feature branch: `git checkout -b feature/YourFeature`
2. Commit changes: `git commit -am 'Add feature'`
3. Push to branch: `git push origin feature/YourFeature`
4. Create a Pull Request
5. Ensure all tests pass
6. Request code review

### Testing Requirements

- Unit tests for business logic
- Integration tests for API endpoints
- Minimum 80% code coverage
- All tests must pass before merge

---

## 📝 License

This project is licensed under the MIT License - see LICENSE file for details.

---

## 📞 Support & Contact

For questions, issues, or feature requests:

- 🐛 [Report Issues](https://github.com/MuTeach0/MechanicShopWorkshop/issues)
- 💬 [Start a Discussion](https://github.com/MuTeach0/MechanicShopWorkshop/discussions)
- 📧 Email: mahmoud.mutech@gmail.com

---

## 🎓 Learning Resources

- [Clean Architecture in .NET](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure)
- [CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [ASP.NET Core 9.0 Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core)
- [Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor)
- [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet)

---

**Built with ❤️Mahmoud❤️ using .NET 9.0 | Last Updated: December 28, 2025**