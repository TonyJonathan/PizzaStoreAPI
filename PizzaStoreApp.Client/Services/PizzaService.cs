using System.Net.Http.Json;
using PizzaStoreApp.Shared.Models;

namespace PizzaStoreApp.Client.Services;

public class PizzaService
{
    private readonly HttpClient _http;

    public PizzaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Pizza>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Pizza>>("https://localhost:7016/api/pizza")
               ?? new List<Pizza>();
    }
}
