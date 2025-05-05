using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaStoreApp.Client;
using PizzaStoreApp.Client.Services; 


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7016")
});

builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<UserService>();



await builder.Build().RunAsync();
