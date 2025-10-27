# Ecommerce Demo Project

**Ecommerce Demo** is a modern .NET application showcasing best practices in **Clean Architecture**, **CQRS patterns**, and **layered design**. This project demonstrates how to structure a scalable and maintainable application while leveraging popular .NET technologies.

## Key Technologies

- **ASP.NET Core 8** – for building RESTful APIs
- **Entity Framework Core** – for relational data access
- **MediatR** – for handling commands, queries, and events
- **AutoMapper** – for mapping between domain entities and DTOs
- **Swagger / OpenAPI** – for API documentation and testing

## Architecture

The project follows **Clean Architecture principles**, separating the solution into distinct layers:

- **Domain** – contains entities and business logic
- **Application** – defines commands, queries, DTOs, and service interfaces
- **Infrastructure** – implements database context, repositories, and external services
- **API** – exposes REST endpoints and integrates with MediatR, AutoMapper, and Swagger

This design ensures **loose coupling**, **testability**, and **maintainability** for real-world applications.

## Features

- **Product Catalog** – manage products with properties like name, description, price, and stock
- **Order Management** – create and retrieve orders with multiple items, supporting relational data
- **CQRS Implementation** – separate read (queries) and write (commands) operations
- **Automated Mapping** – convert entities to DTOs seamlessly using AutoMapper
- **API Documentation** – interactive API docs via Swagger UI

## Database

The application uses **SQL Server** to store relational data. Key relationships include:

- **Orders** → contain multiple **OrderItems**
- **Products** → associated with **OrderItems** in a many-to-one relationship

This setup demonstrates realistic data relationships in an e-commerce scenario.

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/yourusername/ecommerce-demo.git
