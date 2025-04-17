using PizzaStoreAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace PizzaStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:7157") // port Blazor
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PizzaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaDb")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins); 
            app.MapControllers();
            app.Run();
        }
    }
}

