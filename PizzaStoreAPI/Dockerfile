# Étape de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier uniquement le projet API
COPY PizzaStoreAPI/ ./PizzaStoreAPI/
WORKDIR /app/PizzaStoreAPI

# Restaurer, build et publier
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Étape de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/PizzaStoreAPI/out ./
ENTRYPOINT ["dotnet", "PizzaStoreAPI.dll"]
