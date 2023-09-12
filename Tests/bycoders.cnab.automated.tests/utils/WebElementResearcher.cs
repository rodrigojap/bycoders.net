using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace bycoders.cnab.automated.tests.utils
{
    public static class WebElementResearcher
    {                
        public static IWebElement FindElementByClassName(string ClassName, IWebDriver WebDriver)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(2))
                .Until(
                    c => c.FindElement(By.ClassName(ClassName))
                );
        }

        public static IReadOnlyCollection<IWebElement> FindElementsByClassName(string ClassName, IWebDriver WebDriver)
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(2))
                .Until(
                    c => c.FindElements(By.ClassName(ClassName))
                );
        }
    }
}
