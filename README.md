# Retail POS Backend System

## Overview

Retail POS Backend System is a standalone backend application designed to power retail point-of-sale operations. It exposes core business logic for managing sales, products, inventory, and customers, and communicates with a SQL Server database for persistent storage.

The system is designed with scalability, separation of concerns, and clean data access in mind, making it suitable for integration with desktop, web, or mobile frontends.

---

## Core Features

### Sales Processing
- Create and manage sales transactions
- Handle multi-item orders
- Automatic total calculation
- Transaction history tracking

### Product Management
- CRUD operations for products
- Category-based organization
- Price management
- Stock tracking

### Inventory Control
- Real-time stock updates
- Prevent overselling
- Stock adjustment support

### Customer Management
- Store and manage customer data
- Track purchase history per customer

### Reporting
- Sales summaries
- Revenue tracking
- Transaction analytics

---

## Architecture

The project follows a layered structure:

- **API / Service Layer** → Business logic entry point
- **Business Logic Layer (BLL)** → Core rules and validations
- **Data Access Layer (DAL)** → SQL Server communication using ADO.NET
- **Database Layer** → SQL Server schema and procedures

---

## Technologies Used

- C#
- .NET Framework
- SQL Server
- ADO.NET
- RESTfull APIs
