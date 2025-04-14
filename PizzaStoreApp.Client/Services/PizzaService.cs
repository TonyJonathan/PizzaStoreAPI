using System.Net.Http.Json;
using PizzaStoreApp.Client.Models;

namespace PizzaStoreApp.Client.Services
{
    public class PizzaService
    {
        private readonly HttpClient _http;

        public PizzaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Pizza>>("api/pizza") ?? new List<Pizza>();
        }
    }
}
