# 🍕 PizzaStore API

Une API RESTful développée en C# avec ASP.NET Core pour la gestion d’un stock de pizzas.  
Elle utilise Entity Framework Core avec SQL Server pour la persistance des données.

---

## 🚀 Fonctionnalités

- ✅ API REST complète (GET, POST, PUT, DELETE)
- ✅ Stockage des données dans SQL Server via Entity Framework Core
- ✅ Swagger UI pour tester l’API
- ✅ Modèle simple : `Pizza` (Id, Name, IsGlutenFree)

---

## 📦 Technologies utilisées

- ASP.NET Core 7
- C#
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger / Swashbuckle

---

## 📁 Structure

```bash
PizzaStoreAPI/
├── Controllers/
│   └── PizzaController.cs
├── Models/
│   └── Pizza.cs
├── Data/
│   └── PizzaDbContext.cs
├── appsettings.json
├── Program.cs
