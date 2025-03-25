using SeleniumTests.lib.config;
using OpenQA.Selenium.Chrome;
using SeleniumTests.lib.pages;

namespace SeleniumTests.tests;

public class UiHomePageTests
{
    private ChromeDriver?_driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void HomePage_ShouldDisplay_Logo()
    {
        _driver!.Navigate().GoToUrl(Config.BaseUrl);
        var homePage = new HomePage(_driver);

        Assert.That(homePage.Logo.Displayed, Is.True);
    }

    [TearDown]
    public void Teardown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}