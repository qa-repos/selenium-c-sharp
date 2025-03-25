using SeleniumTests.lib.config;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.lib.Base;

public abstract class UiTestBase
{
    private ChromeDriver?_driver;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();

        if (Config.IsCi)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument($"--user-data-dir=/tmp/chrome-user-data-{Guid.NewGuid()}");
        }

        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void Teardown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}