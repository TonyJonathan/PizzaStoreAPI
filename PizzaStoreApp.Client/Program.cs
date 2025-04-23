using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaStoreApp.Client;
using PizzaStoreApp.Client.Services; 


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://pizzastoreapi.onrender.com")
});

builder.Services.AddScoped<PizzaService>();



await builder.Build().RunAsync();
