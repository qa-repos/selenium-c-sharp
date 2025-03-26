using System.Net.Http.Json;
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
        return await _client.GetFromJsonAsync<BooksResponseDto>("/BookStore/v1/Books")
               ?? new BooksResponseDto();
    }

    public async Task<BookDto> GetBookByIsbnAsync(string isbn)
    {
        return await _client.GetFromJsonAsync<BookDto>($"/BookStore/v1/Book?ISBN={isbn}")
               ?? new BookDto();
    }

    public async Task<HttpResponseMessage> CreateUserAsync(UserRequestDto user)
    {
        return await _client.PostAsJsonAsync("/Account/v1/User", user);
    }

    public async Task<TokenResponseDto?> GenerateTokenAsync(UserRequestDto user)
    {
        var res = await _client.PostAsJsonAsync("/Account/v1/GenerateToken", user);
        return await res.Content.ReadFromJsonAsync<TokenResponseDto>();
    }
}
