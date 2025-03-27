using SeleniumTests.lib.Base;
using SeleniumTests.lib.helpers;

namespace SeleniumTests.tests.fixtures;

public class BookStoreFixture : BaseTestWithLogging
{
    protected BookStoreClient Client = null!;

    [SetUp]
    public void SetupClient()
    {
        Client = new BookStoreClient();
    }
}