using PizzaStoreApp.Shared.Models;
using System.Net.Http.Json;

public class UserService
{
    private readonly HttpClient http; 

    public UserService(HttpClient http)
    {
        this.http = http; 
    }

    public async Task<string?> RegisterAsync(RegisterUserDto user)
    {
        var response = await http.PostAsJsonAsync("api/user", user); 

        if(response.IsSuccessStatusCode)
        {
            return null; 
        }

        return await response.Content.ReadAsStringAsync(); 
    }
}