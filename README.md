# 🥬 FarmLink

**A marketplace system for vegetable farmers in Mantalongon, Dalaguete.**

FarmLink connects local vegetable farmers directly with customers. Farmers can list their produce with prices and quantities, and customers can browse the marketplace and add items to a cart.

## ✨ Features

- **Accounts with roles** – register and log in as a *Farmer* or a *Customer*
- **Farmer dashboard** – add, edit and manage product listings (price, quantity, unit)
- **Customer dashboard** – a home page for customers after login
- **Marketplace** – browse available vegetables and view product details
- **Cart** – add products to a cart
- **Database migrations** – schema managed with Entity Framework Core migrations

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 9) |
| Language | C# |
| Database | MySQL (via Pomelo.EntityFrameworkCore.MySql) |
| ORM | Entity Framework Core |
| UI | Razor Views, Bootstrap |

## 📁 Project Structure

```
Controllers/   Account, Farmer, Customer, Product, Marketplace
Models/        User, Product, Cart
ViewModels/    Login, Register, Product
Data/          ApplicationDbContext
Migrations/    EF Core migrations
Views/         Razor pages
```

## 🚀 Getting Started

**Requirements:** .NET 9 SDK, MySQL (e.g. XAMPP)

1. Clone the repo
   ```bash
   git clone https://github.com/Aya12234567/FarmLink.git
   cd FarmLink
   ```
2. Update the connection string in `appsettings.json` if your MySQL user/password is different
3. Create the database
   ```bash
   dotnet ef database update
   ```
4. Run the app
   ```bash
   dotnet run
   ```

## 📸 Screenshots

_Coming soon_
