# Étape de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier les fichiers .csproj et restaurer les dépendances
COPY *.sln .
COPY PizzaStoreAPI/*.csproj ./PizzaStoreAPI/
RUN dotnet restore

# Copier le reste du code
COPY PizzaStoreAPI/. ./PizzaStoreAPI/
WORKDIR /app/PizzaStoreAPI
RUN dotnet publish -c Release -o out

# Étape runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/PizzaStoreAPI/out .
ENTRYPOINT ["dotnet", "PizzaStoreAPI.dll"]
