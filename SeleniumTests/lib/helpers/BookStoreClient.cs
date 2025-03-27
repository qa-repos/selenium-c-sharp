using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using SeleniumTests.lib.config;
using SeleniumTests.lib.models;

namespace SeleniumTests.lib.helpers;

public class BookStoreClient
{
    private readonly HttpClient _client = new();

    public BookStoreClient()
    {
        _client.BaseAddress = new Uri(Config.ApiUrl);
    }

    public async Task<BooksResponseDto> GetAllBooksAsync()
    {
        Console.WriteLine("GET /Books");
        return await _client.GetFromJsonAsync<BooksResponseDto>("/BookStore/v1/Books")
               ?? new BooksResponseDto();
    }

    public async Task<BookDto> GetBookByIsbnAsync(string isbn)
    {
        Console.WriteLine($"GET /Book?ISBN={isbn}");
        return await _client.GetFromJsonAsync<BookDto>($"/BookStore/v1/Book?ISBN={isbn}")
               ?? new BookDto();
    }

    public async Task<HttpResponseMessage> CreateUserAsync(UserRequestDto user)
    {
        Console.WriteLine("POST /User");
        return await _client.PostAsJsonAsync("/Account/v1/User", user);
    }

    public async Task<GetUserResponseDto> GetUserAsync(string userId, string token)
    {
        Console.WriteLine($"GET /Account/v1/User/{userId}");

        var request = new HttpRequestMessage(HttpMethod.Get, $"/Account/v1/User/{userId}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetUserResponseDto>() 
               ?? new GetUserResponseDto();
    }


    public async Task<TokenResponseDto?> GenerateTokenAsync(UserRequestDto user)
    {
        Console.WriteLine("POST /GenerateToken");
        var res = await _client.PostAsJsonAsync("/Account/v1/GenerateToken", user);
        return await res.Content.ReadFromJsonAsync<TokenResponseDto>();
    }

    public async Task<HttpResponseMessage> LoginAsync(UserRequestDto user)
    {
        Console.WriteLine("POST /Login");
        return await _client.PostAsJsonAsync("/Account/v1/Login", user);
    }

    public async Task<HttpResponseMessage> DeleteBookAsync(string isbn, string userId, string token)
    {
        Console.WriteLine("DELETE /Book");
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/BookStore/v1/Book");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = new StringContent(JsonSerializer.Serialize(new
        {
            isbn,
            userId
        }), Encoding.UTF8, "application/json");
        
        return await _client.SendAsync(request);
    }

    public async Task<HttpResponseMessage> DeleteAllBooksAsync(string userId, string token)
    {
        Console.WriteLine("DELETE /Books (all)");
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/BookStore/v1/Books");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = new StringContent(JsonSerializer.Serialize(new { userId }), Encoding.UTF8, "application/json");
        return await _client.SendAsync(request);
    }

    public async Task<HttpResponseMessage> AddBookToUserAsync(string userId, string isbn, string token)
    {
        Console.WriteLine("POST /Books (add)");
        var request = new HttpRequestMessage(HttpMethod.Post, "/BookStore/v1/Books");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = new StringContent(JsonSerializer.Serialize(new
        {
            userId,
            collectionOfIsbns = new[] { new { isbn } }
        }), Encoding.UTF8, "application/json");
        return await _client.SendAsync(request);
    }
}
