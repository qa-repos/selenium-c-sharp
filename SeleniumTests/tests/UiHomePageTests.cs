using NUnit.Framework;
using SeleniumTests.lib.Base;
using SeleniumTests.lib.config;
using SeleniumTests.lib.pages;

namespace SeleniumTests.tests;

public class UiHomePageTests : UiTestBase
{
    [Test]
    public void HomePage_ShouldDisplay_Logo()
    {
        Driver!.Navigate().GoToUrl(Config.BaseUrl);
        var homePage = new HomePage(Driver);

        Assert.That(homePage.Logo.Displayed, Is.True);
    }
}