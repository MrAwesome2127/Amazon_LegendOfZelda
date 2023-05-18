using Amazon_LegendOfZelda.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_LegendOfZelda.Test
{
    public class LOZ
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void LOZ_Socks()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            HomePage homePage = new HomePage(driver);
            homePage.Search_Item();

            SearchResultPage searchResultPage = new SearchResultPage(driver);
            searchResultPage.SelectSocks();
            searchResultPage.AddToCart();
            searchResultPage.ProceedtoCheckout();
        }
    }
}