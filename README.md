# 🍕 PizzaStoreApp

Un projet full-stack composé d'une API REST en ASP.NET Core et d'une interface utilisateur en Blazor WebAssembly, permettant de gérer un stock de pizzas.

---

## 🚀 Fonctionnalités

- ✅ API REST (GET, POST, PUT, DELETE) pour gérer les pizzas
- ✅ Interface Web en Blazor WebAssembly
- ✅ Validation côté client et serveur
- ✅ Swagger UI pour tester l’API
- ✅ Déploiement de l'[API](https://pizzastoreapi.onrender.com/api/pizza)
- ✅ Déploiement de la [démo](https://pizzastoreapp.netlify.app/) 
- ✅ Connexion conditionnelle à **SQL Server en local** et à **PostgreSQL en production (Render)**

---

## 🛠️ Stack

- **Back-end** : ASP.NET Core, Entity Framework Core, SQL Server (local), PostgreSQL (Render), Swagger
- **Front-end** : Blazor WebAssembly, Razor Components, CSS3
- **Hébergement** : Render (API), Netlify (client)

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
│   ├── Migrations/
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
│
└── PizzaStoreApp.sln            # Solution regroupant API et client
