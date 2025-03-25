using SeleniumTests.lib.helpers;

namespace SeleniumTests.tests;

public class ApiBookStoreTests
{
    [Test]
    public async Task GetBooks_ShouldReturnBooksJson()
    {
        var api = new ApiClient();
        var books = await api.GetBooks();

        Assert.That(books, Is.Not.Null);
    }
}