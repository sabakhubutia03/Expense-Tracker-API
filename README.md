# Expense Tracker API

A robust and scalable Backend API built with **.NET 9** following **Clean Architecture** principles. This project manages users, expenses, and categories with a focus on data integrity and clear separation of concerns.

## 🚀 Technologies Used
* **Framework:** .NET 9
* **Database:** Entity Framework Core (SQL Server)
* **Mapping:** AutoMapper
* **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API)
* **Design Patterns:** Repository Pattern, DTOs (Data Transfer Objects)

## ✨ Key Features Implemented

### 📂 Core Functionalities
* **User Management:** Full CRUD operations for users, including DTO-based data transfer.
* **Category Management:** System for organizing expenses into custom categories.
* **Expense Tracking:** Complete expense management with async operations and validation.
* **Global Error Handling:** Centralized middleware for handling exceptions consistently.

### 🛠 Technical Highlights
* **Clean Architecture:** Separation of project into Domain, Application, Infrastructure, and API layers for better maintainability.
* **Data Mapping:** Integrated **AutoMapper** to handle transformations between Domain Entities and DTOs efficiently.
* **Persistence:** Configured `ApplicationDbContext` with support for Users, Expenses, and Categories.
* **Repository Clean-up:** Properly configured `.gitignore` to exclude `bin/obj` and IDE-specific settings.

## 🏗 Project Structure
* **Domain:** Entities and core business logic.
* **Application:** Interfaces, DTOs, Mapping profiles, and Service logic.
* **Infrastructure:** Database context, migrations, and external service implementations.
* **API:** Controllers, Middleware, and Program configuration.

## 🚦 Getting Started
1. Clone the repository.
2. Update the connection string in `appsettings.json`.
3. Run `dotnet ef database update` to apply migrations.
4. Run the project and explore via **Swagger UI**.
