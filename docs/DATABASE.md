# Database Schema

## Overview
The Royal Legal Suite uses a SQL Server database with the following main entities:

## Core Entities

### Clients
- **Id** (int, Primary Key)
- **FirstName** (nvarchar(100))
- **LastName** (nvarchar(100))
- **Email** (nvarchar(255), Unique)
- **PhoneNumber** (nvarchar(20))
- **Address** (nvarchar(500))
- **IsCompany** (bit)
- **CompanyName** (nvarchar(200))
- Base entity fields (CreatedAt, UpdatedAt, etc.)

### Cases
- **Id** (int, Primary Key)
- **CaseNumber** (nvarchar(50), Unique)
- **Title** (nvarchar(200))
- **Description** (ntext)
- **CaseType** (int, Enum)
- **Status** (int, Enum)
- **ClientId** (int, Foreign Key to Clients)
- **AssignedLawyerId** (int, Foreign Key to Users)
- Base entity fields

### Users
- **Id** (int, Primary Key)
- **UserName** (nvarchar(100), Unique)
- **Email** (nvarchar(255), Unique)
- **FirstName** (nvarchar(100))
- **LastName** (nvarchar(100))
- **Role** (int, Enum)
- **HourlyRate** (decimal(18,2))
- **PasswordHash** (nvarchar(255))
- Base entity fields

### Time Entries
- **Id** (int, Primary Key)
- **UserId** (int, Foreign Key to Users)
- **CaseId** (int, Foreign Key to Cases)
- **StartTime** (datetime2)
- **EndTime** (datetime2)
- **Hours** (decimal(18,2))
- **HourlyRate** (decimal(18,2))
- **Description** (ntext)
- **IsBillable** (bit)
- Base entity fields

## Relationships

### One-to-Many
- Client -> Cases
- User -> Cases (as assigned lawyer)
- Case -> Tasks
- Case -> Documents
- Case -> Time Entries

### Many-to-Many
- Cases -> Users (through case assignments)

## Indexes

### Unique Indexes
- Clients.Email
- Users.Email
- Users.UserName
- Cases.CaseNumber
- Invoices.InvoiceNumber

### Performance Indexes
- Cases.ClientId
- Cases.AssignedLawyerId
- TimeEntries.UserId
- TimeEntries.CaseId
- Documents.CaseId