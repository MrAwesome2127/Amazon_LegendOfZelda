using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_LegendOfZelda.Pages
{
    public class SearchResultPage
    {
        public SearchResultPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebDriver driver { get; }

        #region Locators
            private IWebElement btnAddToCart => driver.FindElement(By.Id("add-to-cart-button"));
            private IWebElement btnGotToCasrt => driver.FindElement(By.Id("sw-gtc"));
            private IWebElement imgLOZSock_Bundle => driver.FindElement(By.XPath("//div//img[@alt='Sponsored Ad - Bioworld mens The Legend of Zelda 5-Pack Pair Casual Crew 43689 Socks, Green, 10-13']"));
        #endregion

        public void SelectSocks()
        {
            Assert.That(imgLOZSock_Bundle.Displayed, Is.True);
            imgLOZSock_Bundle.Click();
        }

        public void AddToCart()
        {
            btnAddToCart.Click();
        }
        public void ProceedtoCheckout()
        {
            btnGotToCasrt.Click();
        }
    }
}