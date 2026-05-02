# 🛒 E-Commerce Backend API (E-Commerc-GEM-y)

A scalable and clean **ASP.NET Core Web API** for an e-commerce system built using modern backend practices such as **Clean Architecture (Onion Architecture)**, **Design Patterns**, and **Performance Optimization techniques**.

---

## 🚀 Project Overview

This project provides a complete backend solution for an e-commerce platform with the following core features:

- 🔐 Authentication & Authorization (JWT / Identity)
- 📦 Product Management
- 🧺 Shopping Basket (Cart)
- 🧾 Order Management
- ⚡ Performance Optimization (Caching with Redis)
- 🧠 Clean Architecture with separation of concerns

---

## 🏛 Architecture

The system is built using **Onion Architecture**, ensuring:

- Separation of concerns
- High testability
- Scalability and maintainability
- Independence of business logic from infrastructure

### 📁 Project Structure
E-Commerc-GEM-y/
├── Core/ # Domain Entities & Interfaces
├── Infrastructure/ # Data Access & Repository Implementations
├── RouteDev.Ecommerce.Api/ # API Layer (Controllers)
├── RouteDev.Talabat.sln # Solution File
└── README.md # Documentation


---

## 🔐 Authentication & Authorization

- User Registration & Login
- JWT Token-based Authentication
- Role-based Access Control (Admin / User)
- Secure password handling

> Ensures only authenticated users can access protected resources.

---

## 📦 Main Modules

### 🛍️ Product Module
- CRUD operations for products
- Product filtering by brand and type
- Clean API endpoints for product listing and details

---

### 🧺 Basket Module (Shopping Cart)
- Add products to basket
- Update item quantities
- Remove items
- Retrieve current basket

---

### 🧾 Order Module
- Create orders from basket
- Track order status
- Retrieve user order history

---

## ⚙️ Performance & Optimization

### ⚡ Redis Caching
- Distributed caching using Redis
- Reduces database load
- Improves API response time

### 🧠 Custom Caching Attribute
- Automatic caching of API responses
- Cache key based on request path + query parameters
- Configurable TTL (default: 1200 seconds)

---

## 🧱 Design Patterns Used

### 📌 Repository Pattern
Provides a clean abstraction layer for data access and reusable CRUD operations.

### 📌 Unit of Work Pattern
Ensures transactional consistency across multiple repository operations.

### 📌 Specification Pattern
Used for building flexible and reusable query logic (especially for filtering products).

---

## 🛠️ Tech Stack

| Technology            | Purpose                          |
|----------------------|----------------------------------|
| ASP.NET Core Web API | Backend Framework                |
| C#                   | Programming Language            |
| Entity Framework Core| ORM for Database                |
| SQL Server           | Database                        |
| Redis                | Distributed Caching             |
| JWT / Identity       | Authentication                  |
| Onion Architecture   | System Design                   |
| Design Patterns      | Code Reusability & Maintainability |

---

## 🚀 Getting Started

### 📌 Prerequisites

Make sure you have installed:

- .NET SDK
- SQL Server
- Redis Server (optional but recommended)
- Visual Studio / VS Code

---

### 📥 Installation Steps

```bash
# Clone repository
git clone https://github.com/Gemy33/E-Commerc-GEM-y.git

# Open solution in Visual Studio

# Restore dependencies
dotnet restore

# Run migrations (if applicable)
dotnet ef database update

# Run the project
dotnet run
---
### Example API Request
GET /api/products?brandId=2&typeId=2
🧠 Key Highlights
Clean & scalable architecture
High performance with Redis caching
Real-world backend patterns
Maintainable and testable code structure
Production-ready design approach
📈 Future Improvements
Payment gateway integration
Advanced filtering & sorting
Pagination improvements
Logging & monitoring system
Unit & Integration testing coverage
👨‍💻 Author

Developed as a backend learning & production-level practice project using ASP.NET Core.

📜 License

This project is for educational and portfolio purposes.
