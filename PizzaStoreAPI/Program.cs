using Microsoft.EntityFrameworkCore;
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
                    policy.WithOrigins("https://localhost:7157")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Connexion à la base de données
            string? connectionString;

            var databaseUrl = builder.Configuration["DATABASE_URL"];
            if (!string.IsNullOrEmpty(databaseUrl))
            {
                // Environnement Render : PostgreSQL
                connectionString = ConvertDatabaseUrlToConnectionString(databaseUrl);
                builder.Services.AddDbContext<PizzaDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }
            else
            {
                // Environnement local : SQL Server
                connectionString = builder.Configuration.GetConnectionString("PizzaDb");
                builder.Services.AddDbContext<PizzaDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            // Fonction de conversion pour PostgreSQL (Render)
            static string ConvertDatabaseUrlToConnectionString(string databaseUrl)
            {
                var uri = new Uri(databaseUrl);
                var userInfo = uri.UserInfo.Split(':');

                return $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};" +
                       $"Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
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

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
