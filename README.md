# Royal Legal Suite 🏛️⚖️

A comprehensive legal practice management system built with .NET 8 and clean architecture principles.

## Overview

Royal Legal Suite is a modern, scalable legal practice management solution designed to streamline law firm operations, case management, client relationships, and document handling. Built with professional-grade tools and following industry best practices.

## 🎯 Key Features

### Core Legal Management
- **Case Management**: Complete case lifecycle management with events and participants
- **Client Management**: Comprehensive client data with secure communication
- **Document Management**: Advanced document storage, versioning, and retrieval
- **Time Tracking**: Billable hours and expense tracking with detailed reporting
- **Invoice Management**: Automated billing with line items and payment tracking
- **Task Management**: Team collaboration and deadline management

### Professional Tools
- **Calendar Integration**: Court dates, deadlines, and appointment scheduling
- **Email Automation**: Automated client notifications and invoice reminders
- **Reporting & Analytics**: Comprehensive business intelligence and KPI tracking
- **User Management**: Role-based access control and authentication
- **Professional UI**: Modern, responsive design with law firm branding

### Technical Features
- **RESTful API**: Complete API for integrations and mobile apps
- **Real-time Updates**: Live notifications and status updates
- **Security**: JWT authentication, role-based authorization
- **Scalability**: Clean architecture with separation of concerns

## 🏗️ Architecture

This solution follows a **Clean Architecture** pattern with clear separation of concerns:

```
Royal Legal Suite
├── src/
│   ├── RoyalLegal.Domain/          # Core business entities and rules
│   │   ├── Entities/               # Domain entities (Client, Case, User, etc.)
│   │   └── Enums/                  # Business enumerations
│   ├── RoyalLegal.Application/     # Business logic and use cases
│   │   └── Interfaces/             # Repository and service contracts
│   ├── RoyalLegal.Infrastructure/  # Data access and external services
│   │   └── Data/                   # Entity Framework DbContext
│   ├── RoyalLegal.API/            # RESTful Web API
│   │   └── Controllers/           # API endpoints
│   └── RoyalLegal.Web/            # MVC Web application
│       ├── Controllers/           # Web controllers
│       ├── Views/                 # Razor views
│       └── wwwroot/              # Static files
├── docs/                          # Documentation
├── tests/                         # Unit and integration tests
└── server.ps1                    # Development server script
```

### Domain Entities
- **BaseEntity**: Common properties for all entities
- **Client**: Client information and contact details
- **Case**: Legal cases with events and participants
- **User**: System users with roles and permissions
- **Document**: Document management with metadata
- **TimeEntry**: Billable time tracking
- **Invoice**: Billing and payment management
- **Task**: Work item and deadline tracking

## 🛠️ Technology Stack

### Backend
- **.NET 8**: Latest LTS framework with improved performance
- **ASP.NET Core**: Web API and MVC framework
- **Entity Framework Core**: Object-relational mapping
- **SQL Server**: Primary relational database
- **JWT**: Secure authentication and authorization

### Frontend
- **Bootstrap 5.1.3**: Responsive UI framework
- **Font Awesome**: Professional iconography
- **Custom CSS**: Professional law firm styling
- **Razor Views**: Server-side rendering

### Development Tools
- **Visual Studio Code**: Primary IDE
- **C# Dev Kit**: Enhanced C# development experience
- **SQL Server Extension**: Database management and queries
- **REST Client**: API testing and documentation
- **Calendar Integration**: Appointment and deadline management
- **Document Viewers**: Excel, PDF, and Office file support

### DevOps & Quality
- **PowerShell**: Automation and deployment scripts
- **Git**: Version control and collaboration
- **Code Runner**: Quick testing and execution
- **Professional Design**: Navy blue and charcoal gray color scheme

## 🚀 Getting Started

### Prerequisites
- **.NET 8 SDK** - [Download from Microsoft](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** (LocalDB for development) - [Download SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Visual Studio Code** - [Download VS Code](https://code.visualstudio.com/)
- **Git** - [Download Git](https://git-scm.com/downloads)

### Quick Setup
1. **Clone the repository**
   ```bash
   git clone https://github.com/licjorgefab/Royal-Legal-Suite.git
   cd Royal-Legal-Suite
   ```

2. **Install VS Code Extensions** (automatically installed)
   - C# Dev Kit
   - SQL Server (mssql)
   - REST Client
   - Calendar
   - Excel Viewer
   - Office Viewer
   - Code Runner

3. **Restore packages**
   ```bash
   dotnet restore
   ```

4. **Build the solution**
   ```bash
   dotnet build
   ```

5. **Run the web application**
   ```bash
   dotnet run --project src/RoyalLegal.Web
   ```

6. **Run the API** (in separate terminal)
   ```bash
   dotnet run --project src/RoyalLegal.API
   ```

### Alternative: HTTP Server for Frontend Demo
For quick frontend preview without .NET SDK:
```powershell
# Run the PowerShell HTTP server
.\server.ps1
# Navigate to http://localhost:8000
```

## 💻 Development

### Available VS Code Tasks
- **build**: Build the entire solution
- **restore**: Restore NuGet packages
- **clean**: Clean build artifacts
- **run-api**: Start the API server (background)
- **run-web**: Start the web application (background)

### Building the Solution
```bash
# Full solution build
dotnet build

# Restore packages
dotnet restore

# Clean artifacts
dotnet clean
```

### Running Tests
```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/RoyalLegal.Tests
```

### Database Management
```bash
# Create migration
dotnet ef migrations add InitialCreate --project src/RoyalLegal.Infrastructure

# Update database
dotnet ef database update --project src/RoyalLegal.Infrastructure
```

### API Development
The API provides comprehensive endpoints for:
- `/api/clients` - Client management
- `/api/cases` - Case management
- `/api/documents` - Document handling
- `/api/timEntries` - Time tracking
- `/api/invoices` - Billing management

Use the REST Client extension to test API endpoints with the provided `.http` files.

## 🎨 UI Design

The application features a professional legal firm design with:
- **Color Scheme**: Navy blue (#1e3c72) and charcoal gray (#2c3e50)
- **Typography**: Professional, readable fonts
- **Imagery**: High-quality law firm and courthouse photography
- **Responsive**: Bootstrap-based responsive design
- **Accessibility**: WCAG 2.1 compliance considerations

## 📊 Project Status

### ✅ Completed
- [x] Clean architecture solution structure
- [x] Domain entities and business logic
- [x] Entity Framework Core setup
- [x] API controllers foundation
- [x] MVC web application structure
- [x] Professional UI design
- [x] PowerShell development server
- [x] VS Code development environment

### 🚧 In Progress
- [ ] Database migrations and seeding
- [ ] Complete API implementation
- [ ] Authentication and authorization
- [ ] Unit and integration tests
- [ ] Document management features

### 📋 Planned Features
- [ ] Email automation (MailKit integration)
- [ ] Calendar synchronization (Outlook/Google)
- [ ] Advanced reporting and analytics
- [ ] Mobile application
- [ ] Third-party integrations
- [ ] Advanced document workflows

## 🤝 Contributing

We welcome contributions! Please follow these guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Code Standards
- Follow C# coding conventions
- Include unit tests for new features
- Update documentation as needed
- Use meaningful commit messages

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Contact

**Developer**: Jorge Fabián  
**Email**: licjorgefab@gmail.com  
**GitHub**: [@licjorgefab](https://github.com/licjorgefab)

## 🙏 Acknowledgments

- Built with ❤️ for legal professionals
- Inspired by modern software development practices
- Powered by the .NET ecosystem
- Designed for scalability and maintainability

---

**Royal Legal Suite** - *Empowering Legal Excellence Through Technology* ⚖️