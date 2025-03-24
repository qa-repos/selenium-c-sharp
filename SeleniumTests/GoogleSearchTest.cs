using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQaTests;

public class HeaderLogoTest
{
    private IWebDriver?driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void Header_ShouldContain_Logo()
    {
        driver!.Navigate().GoToUrl("https://demoqa.com");
        var logo = driver.FindElement(By.XPath("//header/a/img"));

        Assert.That(logo.Displayed, Is.True);
    }

    [TearDown]
    public void Teardown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}
