using bycoders.cnab.automated.tests.utils;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace bycoders.cnab.automated.tests.pages
{
    public class CNABPage
    {
        private IWebDriver _driver;

        public enum Browsers
        {
            CHROME,
            FIREFOX,
        }
        
        public CNABPage(Browsers SelectedBrowser)
        {
            switch (SelectedBrowser)
            {
                case Browsers.CHROME:
                    _driver = new ChromeDriver();
                    break;
                case Browsers.FIREFOX:
                    _driver = new FirefoxDriver();
                    break;                
                default:
                    _driver = new ChromeDriver();
                    break;
            }
        }

        public void LoadPage()
        {            
            _driver.Navigate()
                .GoToUrl("http://localhost:3000/");
        }
        
        
        public void AttachFileButtonClick()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory.Split("bin");
            var filePath = $"{rootPath[0]}resources\\CNAB.txt";

            var result = WebElementResearcher.FindElementByClassName("input-attach", _driver);
            result.SendKeys(filePath);
        }
        
        public void UploadSubmitButtonClick()
        {
            var result = WebElementResearcher.FindElementByClassName("btn-submit-class", _driver);                
            result.Click();
        }


        public void FirstUnorderedElementClick()
        {
            var result = WebElementResearcher.FindElementsByClassName("store-list-item", _driver);
            result.First().Click();
        }

        public string GetMessageText(string className)
        {
            var result = WebElementResearcher.FindElementByClassName(className, _driver);            
            return result.Text;
        }
    }
}
