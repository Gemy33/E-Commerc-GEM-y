# 🛒 E-Commerce API (E-Commerc-GEM-y)

This is a RESTful **E-Commerce API** built with ASP.NET Core following **Onion Architecture**, designed to handle product management, user authentication, basket management, and order processing. The architecture uses **Unit of Work**, **Generic Repository** patterns, and is structured to support clean separation of concerns.

---

## 🧠 Project Overview

This project provides backend functionality for an e-commerce system with the following responsibilities:

✅ Authentication & Authorization  
✅ Product Management  
✅ Basket (Shopping Cart)  
✅ Order Management  
✅ Onion Architecture with layered separation  
✅ Unit of Work and Generic Repository Patterns

---

## 🏛 Architecture

The project is structured according to **Onion Architecture** (similar to Clean Architecture), which helps make the code more **maintainable**, **testable**, and **scalable**. The goal is to reduce direct dependency on infrastructure and push domain logic to the center. :contentReference[oaicite:0]{index=0}
E-Commerc-GEM-y/
├── Core/ → Domain Entities & Interfaces
├── Infrastructure/ → Data persistence & repository implementations
├── RouteDev.Ecommerce.Api/ → API project (Controllers / Startup)
├── RouteDev.Talabat.sln → Solution file
└── README.md → Project documentation

---

## 🔐 Authentication (Auth)

- User registration and login endpoints
- Token-based authentication (likely JWT or Identity based)
- Secure password management
- Role-based access support (Admin / User)

> Authentication ensures that only registered and logged-in users can access protected API resources.

---

## 🛍️ Business Modules

### 📦 Product Module
- Create, Read, Update, Delete products
- Product details and listing endpoints
- Structured with domain entities and API controllers

---

### 🧺 Basket (Shopping Cart)
- Add items to basket
- Update basket items
- Remove items
- Retrieve current basket contents

---

### 🧾 Order Module
- Place orders based on current basket
- Track orders by user
- Order history and status management

---

## 🧱 Design Patterns

### 📌 Generic Repository
The project uses a **Generic Repository Pattern** to provide reusable CRUD operations for all entity types — this reduces repetitive code and centralizes data access logic. :contentReference[oaicite:1]{index=1}

---

### 🏁 Unit of Work
The **Unit of Work** pattern ensures that multiple repository operations are executed within a single transaction — which helps manage consistency across multiple business actions. :contentReference[oaicite:2]{index=2}

---

## 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| ASP.NET Core | Backend Web API framework |
| C# | Core programming language |
| Entity Framework Core | ORM for DB operations |
| Onion Architecture | Layered architecture |
| JWT or ASP.NET Identity | Authentication |
| Generic Repository | Reusable data access |
| Unit of Work | Transaction management |

---

## 🚀 Getting Started

### 📌 Prerequisites

Make sure you have:

- .NET SDK installed
- SQL Server / Database
- IDE like Visual Studio or VS Code

### 📥 Setup & Run

1. Clone the repository:
   git clone https://github.com/Gemy33/E-Commerc-GEM-y.git
2. Open the solution in Visual Studio.

3. Configure your database connection in appsettings.json.

4. Restore packages and build the solution.

5. Run the API (F5 or dotnet run).
