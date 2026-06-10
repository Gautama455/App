using System.Net.Http;
using System.Net.Http.Json;
using App.UI.Models;

namespace App.UI.Settings;

public class ApiService
{
    private HttpClient _client = new HttpClient();

    public ApiService() => _client.BaseAddress = new Uri(App.Settings.url.Users);

    public async Task<IEnumerable<UserUI>> GetUsers()
    {
        var response = await _client.GetAsync("");
        return await response.Content.ReadFromJsonAsync<IEnumerable<UserUI>>();
    }
}