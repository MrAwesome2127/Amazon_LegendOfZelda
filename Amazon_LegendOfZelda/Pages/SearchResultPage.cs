using Amazon_LegendOfZelda.Utilities;
using OpenQA.Selenium;

namespace Amazon_LegendOfZelda.Pages
{
    public class SearchResultPage : Base
    {
        private IWebDriver _driver;
        public SearchResultPage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        #region Locators
            private IWebElement btnAddToCart => _driver.FindElement(By.Id("add-to-cart-button"));
            private IWebElement btnGotToCart => _driver.FindElement(By.Id("nav-cart"));
            private IWebElement product_LOZ => _driver.FindElement(By.XPath("(//*[@class=\"s-image\"])[2]"));
            private IWebElement Popup_SideSheets => _driver.FindElement(By.Id("attach-close_sideSheet-link"));
            private IWebElement imgLOZSock_Bundle => _driver.FindElement(By.XPath("(//img[@alt='Sponsored Ad - Bioworld mens The Legend of Zelda 5-Pack Pair Casual Crew 43689 Socks, Green, 10-13'])[1]"));
        #endregion

        public void AddProduct()
        {
            Assert.That(product_LOZ.Displayed, Is.True);
            product_LOZ.Click();
        }

        public void AddToCart()
        {
            btnAddToCart.Click();
            
            //Pop up appears after the second item is selected.
            try
            {
                Popup_SideSheets.Click();
                Thread.Sleep(1000);
                Console.WriteLine("Pop up SideSheets was display!");
            }
            catch
            {
                Console.WriteLine("Pop up SideSheets, did NOT display!");
            }
        }
        public void ProceedtoCheckout()
        {
            btnGotToCart.Click();
        }
    }
}