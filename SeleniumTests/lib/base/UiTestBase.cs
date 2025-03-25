using SeleniumTests.lib.config;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.lib.Base;

public abstract class UiTestBase
{
    protected ChromeDriver?Driver;

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
        }

        Driver = new ChromeDriver(options);
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void Teardown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}