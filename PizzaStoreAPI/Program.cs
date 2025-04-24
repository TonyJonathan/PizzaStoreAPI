using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PizzaStoreAPI.Data;

namespace PizzaStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // CORS pour autoriser Blazor (localhost:7157 en local)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins("https://pizzastoreapp.netlify.app")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Connexion à la base de données
            string? connectionString;
            var databaseUrl = builder.Configuration["DATABASE_URL"];
            connectionString = "Host=localhost;Port=5432;Database=dummy;Username=dummy;Password=dummy";
            builder.Services.AddDbContext<PizzaDbContext>(options =>
                options.UseNpgsql(connectionString)
                       .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));

            // Fonction de conversion pour PostgreSQL (Render)
            string ConvertDatabaseUrlToConnectionString(string? databaseUrl)
            {
                if (string.IsNullOrEmpty(databaseUrl))
                    throw new InvalidOperationException("DATABASE_URL is not set.");

                var uri = new Uri(databaseUrl);
                var userInfo = uri.UserInfo.Split(':');

                var host = uri.Host;
                var port = uri.Port > 0 ? uri.Port : 5432; // Défaut : 5432
                var db = uri.AbsolutePath.TrimStart('/');
                var user = userInfo[0];
                var pwd = userInfo[1];

                return $"Host={host};Port={port};Database={db};Username={user};Password={pwd};SSL Mode=Require;Trust Server Certificate=true";
            }

            // Ajout des services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (!app.Environment.IsProduction())
            {
                app.UseHttpsRedirection();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.MapControllers();

            // Appliquer les migrations automatiquement si PostgreSQL (Render)
            if (!string.IsNullOrEmpty(databaseUrl))
            {
                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<PizzaDbContext>();
                    try
                    {
                        db.Database.Migrate();
                        Console.WriteLine("Connexion à la base réussie et migrations appliquées.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur de connexion à la base : " + ex.Message);
                    }
                }
            }

            app.Run();
        }
    }
}
