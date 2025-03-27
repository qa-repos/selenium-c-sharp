using NUnit.Framework;
using SeleniumTests.lib.helpers;

namespace SeleniumTests.tests.fixtures;

public class BookStoreFixture
{
    protected BookStoreClient Client = null!;

    [SetUp]
    public void SetupClient()
    {
        Client = new BookStoreClient();
    }
}