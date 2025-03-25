using OpenQA.Selenium;
using SeleniumTests.lib.selectors;

namespace SeleniumTests.lib.pages;

public class HomePage(IWebDriver driver)
{
    public IWebElement Logo => driver.FindElement(By.CssSelector(HomePageSelectors.Logo));
}