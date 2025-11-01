# API Documentation

## Overview
The Royal Legal Suite API provides RESTful endpoints for managing legal cases, clients, documents, and billing.

## Base URL
```
https://localhost:7000/api
```

## Authentication
The API uses JWT (JSON Web Tokens) for authentication. Include the token in the Authorization header:
```
Authorization: Bearer <your-jwt-token>
```

## Endpoints

### Clients
- `GET /clients` - Get all clients
- `GET /clients/{id}` - Get client by ID
- `POST /clients` - Create new client
- `PUT /clients/{id}` - Update client
- `DELETE /clients/{id}` - Delete client

### Cases
- `GET /cases` - Get all cases
- `GET /cases/{id}` - Get case by ID
- `POST /cases` - Create new case
- `PUT /cases/{id}` - Update case
- `DELETE /cases/{id}` - Delete case

### Users
- `GET /users` - Get all users
- `GET /users/{id}` - Get user by ID
- `POST /users` - Create new user
- `PUT /users/{id}` - Update user

### Time Entries
- `GET /timeentries` - Get all time entries
- `POST /timeentries` - Create new time entry
- `PUT /timeentries/{id}` - Update time entry

### Invoices
- `GET /invoices` - Get all invoices
- `GET /invoices/{id}` - Get invoice by ID
- `POST /invoices` - Create new invoice

## Error Responses
The API returns standard HTTP status codes:
- `200` - Success
- `201` - Created
- `400` - Bad Request
- `401` - Unauthorized
- `404` - Not Found
- `500` - Internal Server Error

## Rate Limiting
API requests are limited to 1000 requests per hour per user.