using SeleniumTests.lib.helpers;
using SeleniumTests.lib.models;

namespace SeleniumTests.tests;

[TestFixture]
public class ApiBookStoreTests
{
    private BookStoreClient _client = null!;

    [SetUp]
    public void Setup()
    {
        _client = new BookStoreClient();
    }

    [Test]
    public async Task GetAllBooks_ShouldReturn_NonEmptyList()
    {
        var books = await _client.GetAllBooksAsync();
        Assert.That(books.Books, Is.Not.Empty);
    }

    [Test]
    public async Task GetBookByIsbn_ShouldReturn_ValidBook()
    {
        var books = await _client.GetAllBooksAsync();
        var firstIsbn = books.Books.First().ISBN;

        var book = await _client.GetBookByIsbnAsync(firstIsbn);

        Assert.That(book.Title, Is.Not.Empty);
        Assert.That(book.ISBN, Is.EqualTo(firstIsbn));
    }

    [Test]
    public async Task CreateUser_ShouldReturn_201()
    {
        var user = new UserRequestDto
        {
            UserName = $"user_{Guid.NewGuid():N}",
            Password = "P@ssword123"
        };

        var response = await _client.CreateUserAsync(user);
        Assert.That((int)response.StatusCode, Is.EqualTo(201));
    }

    [Test]
    public async Task GenerateToken_ShouldReturn_ValidToken()
    {
        var user = new UserRequestDto
        {
            UserName = $"user_{Guid.NewGuid():N}",
            Password = "P@ssword123"
        };
        
        await _client.CreateUserAsync(user);

        var token = await _client.GenerateTokenAsync(user);

        Assert.That(token, Is.Not.Null);
        Assert.That(token!.Token, Is.Not.Empty);
        Assert.That(token.Status, Is.EqualTo("Success"));
    }
}