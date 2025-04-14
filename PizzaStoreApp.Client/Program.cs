using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaStoreApp.Client;
using PizzaStoreApp.Client.Components;
using PizzaStoreApp.Client.Services; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure le HttpClient pour appeler ton API ASP.NET Core
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7016/") 
});

// Enregistre le service PizzaService
builder.Services.AddScoped<PizzaService>();

await builder.Build().RunAsync();
