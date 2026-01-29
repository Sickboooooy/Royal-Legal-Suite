# CLAUDE.md - Royal Legal Suite

## Project Overview

Royal Legal Suite is a legal practice management system built with .NET 8 and ASP.NET Core, following Clean Architecture principles. It provides case management, client management, billing, document management, and time tracking for law firms.

## Tech Stack

- **Runtime:** .NET 8 (LTS)
- **Web Framework:** ASP.NET Core 8 (REST API + MVC)
- **ORM:** Entity Framework Core 8 with SQL Server
- **Auth:** JWT Bearer tokens
- **Mapping:** AutoMapper 12
- **Validation:** FluentValidation 11
- **Mediator:** MediatR 12 (CQRS-ready)
- **Logging:** Serilog
- **Caching:** StackExchange.Redis
- **API Docs:** Swashbuckle / Swagger
- **Real-time:** SignalR
- **Frontend:** Bootstrap 5, Font Awesome 6, Razor Views

## Architecture

```
RoyalLegal.Domain          # Entities, enums, base types (no dependencies)
    ↑
RoyalLegal.Application     # Interfaces, DTOs, business logic (depends on Domain)
    ↑
RoyalLegal.Infrastructure  # DbContext, repositories, EF Core (depends on Domain + Application)
    ↑
RoyalLegal.API             # REST API controllers, Swagger (depends on Application + Infrastructure)
RoyalLegal.Web             # MVC controllers, Razor views (depends on Application + Infrastructure)
```

**Key patterns:**
- Clean Architecture with strict dependency direction (inward only)
- Repository pattern (`IRepository<T>`) with specialized repositories per entity
- Unit of Work pattern (`IUnitOfWork`) for transaction management
- Soft delete via `IsDeleted` flag on `BaseEntity`
- Audit trail via `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy` on all entities

## Directory Structure

```
Royal-Legal-Suite/
├── RoyalLegalSuite.sln              # Solution file (5 projects)
├── index.html                       # Standalone frontend demo
├── server.ps1                       # PowerShell dev server (port 8000)
├── docs/
│   ├── API.md                       # API endpoint documentation
│   └── DATABASE.md                  # Database schema documentation
└── src/
    ├── RoyalLegal.Domain/
    │   ├── Entities/                # BaseEntity, Client, Case, User, Task, etc.
    │   └── Enums/                   # CaseType, CaseStatus, Priority, TaskStatus, etc.
    ├── RoyalLegal.Application/
    │   └── Interfaces/              # IRepository<T>, IUnitOfWork, specialized repos
    ├── RoyalLegal.Infrastructure/
    │   └── Data/                    # RoyalLegalDbContext (EF Core config)
    ├── RoyalLegal.API/
    │   ├── Controllers/             # ClientsController, CasesController, etc.
    │   └── appsettings.json         # Connection strings, JWT settings
    └── RoyalLegal.Web/
        ├── Controllers/             # HomeController (MVC)
        ├── Views/                   # Razor views (Home, Shared/_Layout)
        └── wwwroot/css/             # Custom CSS
```

## Build & Run Commands

```bash
# Restore packages
dotnet restore

# Build entire solution
dotnet build

# Run the API (https://localhost:7000)
dotnet run --project src/RoyalLegal.API

# Run the Web MVC app
dotnet run --project src/RoyalLegal.Web

# Clean build artifacts
dotnet clean

# Database migrations
dotnet ef migrations add <MigrationName> --project src/RoyalLegal.Infrastructure --startup-project src/RoyalLegal.API
dotnet ef database update --startup-project src/RoyalLegal.API

# Run tests (not yet implemented)
dotnet test
```

## Domain Entities

11 entities total. All inherit from `BaseEntity` (Id, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, IsDeleted):

| Entity | Key Purpose |
|---|---|
| Client | Law firm clients with contact info, SSN |
| Case | Legal cases with type, status, priority, dates |
| User | System users with roles and bar numbers |
| Task | Case-related tasks with assignment |
| TimeEntry | Billable time tracking (computed TotalAmount) |
| Invoice | Billing with payment tracking (computed BalanceDue) |
| InvoiceLineItem | Invoice line items |
| Document | File management with metadata |
| CaseEvent | Calendar events tied to cases |
| CaseParticipant | Case parties (opposing counsel, etc.) |

**Enums:** CaseType (12), CaseStatus (8), Priority (4), TaskStatus (5), DocumentType (8), UserRole (5), InvoiceStatus (5)

## Database Configuration

- **Dev DB:** SQL Server LocalDB (`(localdb)\mssqllocaldb`, database `RoyalLegalSuiteDb`)
- **Financial fields:** `decimal(18,2)` precision; tax rates use `decimal(5,4)`
- **Unique indexes:** Client.Email, User.Email, User.UserName, Case.CaseNumber, Invoice.InvoiceNumber
- **Delete behavior:** Cascade for child collections (Tasks, Documents, Events, LineItems); Restrict for reference relationships (Client→Cases, User→Cases)

## Coding Conventions

- **Namespaces:** File-scoped (`namespace RoyalLegal.Domain;`)
- **Nullable:** Enabled project-wide (`<Nullable>enable</Nullable>`)
- **Implicit usings:** Enabled
- **Naming:** PascalCase for types/methods/properties; camelCase for locals; `I` prefix for interfaces
- **Async:** All I/O operations use async/await
- **Controllers:** `[ApiController]` with `[Route("api/[controller]")]` for API; standard MVC routing for Web
- **Entity defaults:** Properties initialized with default values (e.g., `string.Empty`, `DateTime.UtcNow`)

## API Conventions

- Base path: `/api/[controller]`
- Standard REST verbs: GET (list), GET/{id}, POST, PUT/{id}, DELETE/{id}
- JWT Bearer auth via `Authorization` header
- CORS: AllowAll policy in development
- Swagger UI available in development mode

## Current Project Status

**Completed:** Clean architecture structure, domain entities, EF Core setup, API controller stubs, MVC web app, professional UI, documentation.

**In progress / stubbed:** Database migrations, full API implementation (controllers have TODOs), authentication flow, testing.

**Planned:** Email automation, calendar sync, reporting, mobile app, third-party integrations.

## Notes for AI Assistants

- API controllers in `src/RoyalLegal.API/Controllers/` are **stubs with TODO comments** — they need full implementation wired to repositories.
- No test projects exist yet. When creating tests, use xUnit (standard for .NET 8) and place them in a `tests/` directory.
- No CI/CD pipelines exist. No Docker configuration.
- The `index.html` at the root is a standalone frontend demo, separate from the Razor-based MVC app.
- JWT secret in `appsettings.json` is a placeholder — do not treat it as a real secret.
- The solution file references a `tests` folder but no test projects have been created yet.
