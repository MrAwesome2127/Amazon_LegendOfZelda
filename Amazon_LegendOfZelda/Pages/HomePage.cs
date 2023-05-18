using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_LegendOfZelda.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebDriver driver { get; }

        //string url = ("appsettings.json").ToLower("URL").ToString;

        #region Locators
            public IWebElement fldSearch => driver.FindElement(By.Id("twotabsearchtextbox"));
            public IWebElement btnSearch => driver.FindElement(By.Id("nav-search-submit-button"));
        #endregion

        public void NavigateURL()
        {

        }
        public void Search_Item()
        {
            Assert.That(fldSearch.Displayed, Is.True);
            fldSearch.SendKeys("Legend Of Zelda Socks");
            btnSearch.Click();
        }
    }
}
