# 🍕 PizzaStoreApp

Un projet full-stack composé d'une API REST en ASP.NET Core et d'une interface utilisateur en Blazor WebAssembly, permettant de gérer un stock de pizzas.

---

## 🚀 Fonctionnalités

- ✅ API REST (GET, POST, PUT, DELETE) pour gérer les pizzas
- ✅ Interface Web en Blazor WebAssembly
- ✅ Stockage des données dans SQL Server via Entity Framework Core
- ✅ Affichage, ajout, modification et suppression de pizzas
- ✅ Validation côté client et serveur
- ✅ Swagger UI pour tester l’API

---

## 🛠️ Stack

- **Back-end** : ASP.NET Core, Entity Framework Core, SQL Server, Swagger
- **Front-end** : Blazor WebAssembly, Razor Components, Bootstrap, CSS3

---

## 📁 Structure du projet

```bash
PizzaStoreApp/
├── PizzaStoreAPI/                # API ASP.NET Core
│   ├── Controllers/
│   │   └── PizzaController.cs
│   ├── Models/
│   │   └── Pizza.cs
│   ├── Data/
│   │   └── PizzaDbContext.cs
│   ├── appsettings.json
│   └── Program.cs
│
├── PizzaStoreApp.Client/        # Front-end Blazor WebAssembly
│   ├── Pages/
│   │   └── Pizzas.razor
│   ├── Services/
│   │   └── PizzaService.cs
│   ├── wwwroot/
│   │   └── style.css
│   └── Program.cs
