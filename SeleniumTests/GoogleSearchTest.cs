using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests;

public class HeaderLogoTest
{
    private ChromeDriver?_driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void Header_ShouldContain_Logo()
    {
        _driver!.Navigate().GoToUrl("https://demoqa.com");
        var logo = _driver.FindElement(By.XPath("//header/a/img"));

        Assert.That(logo.Displayed, Is.True);
    }

    [TearDown]
    public void Teardown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}
