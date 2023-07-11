using Amazon_LegendOfZelda.Utilities;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Amazon_LegendOfZelda.Pages
{
    public class HomePage : Base
    {
        IWebDriver _driver;
        IConfiguration _capabilities = new ConfigurationBuilder()
            .AddJsonFile(@"appsettings.json", optional: true).Build();

        public HomePage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        #region Locators
            public IWebElement fldSearch => _driver.FindElement(By.Id("twotabsearchtextbox"));
            public IWebElement btnSearch => _driver.FindElement(By.Id("nav-search-submit-button"));
        #endregion

        public void NavigateURL()
        {
            var url = _capabilities.GetSection("URL").Value;
            _driver.Url = url;
            _driver.Navigate().Refresh(); //Amazon HomePage has a random offset page appear, "refresh" will resolve the issue.
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void Search_Item(string SearchItem)
        {
            Assert.That(fldSearch.Displayed, Is.True);
            fldSearch.Clear();
            fldSearch.SendKeys(SearchItem);
            btnSearch.Click();
        }
    }
}
