using SeleniumTests.lib.models;
using SeleniumTests.tests.fixtures;

namespace SeleniumTests.tests.api;

[TestFixture]
public class AuthTests : BookStoreFixture
{
    [Test]
    public async Task CreateUser_ShouldReturn_201()
    {
        var user = new UserRequestDto
        {
            UserName = $"user_{Guid.NewGuid():N}",
            Password = "P@ssword123"
        };

        var response = await Client.CreateUserAsync(user);
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

        await Client.CreateUserAsync(user);
        var token = await Client.GenerateTokenAsync(user);

        Assert.That(token, Is.Not.Null);
        Assert.That(token!.Token, Is.Not.Empty);
        Assert.That(token.Status, Is.EqualTo("Success"));
    }

    [Test]
    public async Task Login_WithInvalidCredentials_ShouldFail()
    {
        var user = new UserRequestDto
        {
            UserName = "invalid_user",
            Password = "wrongpass"
        };

        var response = await Client.LoginAsync(user);
        Assert.That((int)response.StatusCode, Is.EqualTo(400));
    }

    [Test]
    public async Task DeleteBooks_WithInvalidToken_ShouldFail()
    {
        var response = await Client.DeleteAllBooksAsync("fake-user-id", "invalid_token");
        Assert.That((int)response.StatusCode, Is.EqualTo(401));
    }
}