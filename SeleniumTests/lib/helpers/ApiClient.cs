using SeleniumTests.lib.config;

namespace SeleniumTests.lib.helpers;

public class ApiClient
{
    private readonly HttpClient _client = new();

    public ApiClient()
    {
        _client.BaseAddress = new Uri(Config.ApiUrl);
    }

    public async Task<string> GetBooks()
    {
        var response = await _client.GetAsync($"/BookStore/v1/Books");
        var book = await response.Content.ReadAsStringAsync();
        return book;
    }
}
