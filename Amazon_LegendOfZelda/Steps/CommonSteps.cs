using Amazon_LegendOfZelda.Pages;
using Amazon_LegendOfZelda.Utilities;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Runtime.InteropServices;
using TechTalk.SpecFlow;

namespace Amazon_LegendOfZelda.Steps
{
    [Binding]
    public class CommonSteps : Base
    {
        HomePage homePage;
        SearchResultPage searchResultPage;
        public CommonSteps()
        {
            homePage = new HomePage(getDriver());
            searchResultPage = new SearchResultPage(getDriver());
        }

        [Given(@"I navigate to the URL")]
        public void GivenINavigateToTheURL()
        {
            //TODO: Assembly is bypassing Setup() on  Base.cs
            homePage.NavigateURL();
        }

        [When(@"I search for '([^']*)'")]
        public void WhenISearchFor(string SearchItem)
        {
            string thisSearchItem = getJsonData().TestData_extractJson("SearchItem");
            homePage.Search_Item(thisSearchItem);
        }

        [When(@"I put socks into my cart")]
        public void WhenIPutSocksIntoMyCart()
        {
            searchResultPage.AddProduct();
            searchResultPage.AddToCart();
            searchResultPage.ProceedtoCheckout();
        }
    }
}
