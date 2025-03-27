using System.Net.Http.Json;
using SeleniumTests.lib.models;
using SeleniumTests.tests.fixtures;

namespace SeleniumTests.tests.api;

[TestFixture]
public class BookTests : BookStoreFixture
{
    private UserRequestDto _user = null!;
    private string _token = null!;
    private string _userId = null!;

    [SetUp]
    public async Task InitUser()
    {
        _user = new UserRequestDto
        {
            UserName = $"user_{Guid.NewGuid():N}",
            Password = "P@ssword123"
        };

        var createRes = await Client.CreateUserAsync(_user);
        Assert.That((int)createRes.StatusCode, Is.EqualTo(201));

        var responseBody = await createRes.Content.ReadFromJsonAsync<CreateUserResponseDto>();
        _userId = responseBody!.UserID;

        var tokenRes = await Client.GenerateTokenAsync(_user);
        _token = tokenRes!.Token;
        Assert.That(_token, Is.Not.Empty);
    }

    [Test]
    public async Task AddBookToUser_ShouldReturn201()
    {
        var books = await Client.GetAllBooksAsync();
        var isbn = books.Books.First().ISBN;

        var addRes = await Client.AddBookToUserAsync(_userId, isbn, _token);
        Assert.That((int)addRes.StatusCode, Is.EqualTo(201));
    }

    [Test]
    public async Task DeleteBookFromUser_ShouldReturn204()
    {
        var books = await Client.GetAllBooksAsync();
        var isbn = books.Books.First().ISBN;
        await Client.AddBookToUserAsync(_userId, isbn, _token);

        var delRes = await Client.DeleteBookAsync(isbn, _userId, _token);
        Assert.That((int)delRes.StatusCode, Is.EqualTo(204));
    }

    [Test]
    public async Task DeleteAllBooks_ShouldReturn204()
    {
        var books = await Client.GetAllBooksAsync();
        var isbn = books.Books.First().ISBN;
        await Client.AddBookToUserAsync(_userId, isbn, _token);

        var delRes = await Client.DeleteAllBooksAsync(_userId, _token);
        Assert.That((int)delRes.StatusCode, Is.EqualTo(204));
    }
}