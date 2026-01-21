using Amazon_LegendOfZelda.Pages;
using Amazon_LegendOfZelda.Utilities;

namespace Amazon_LegendOfZelda.Test;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class LOZ : Base
{
    [Parallelizable(ParallelScope.All)]

    [Test, 
    TestCaseSource(nameof(TCDataConfig_SingleItem)), 
    Category("Regression")]
    public void LOZ_Socks(string SearchItem)
    {
        HomePage homePage = new HomePage(getDriver());
        homePage.NavigateURL();
        homePage.Search_Item(SearchItem);

        SearchResultPage searchResultPage = new SearchResultPage(getDriver());
        searchResultPage.AddProduct();
        searchResultPage.AddToCart();
        searchResultPage.ProceedtoCheckout();
    }

    [Test, 
    TestCaseSource(nameof(TCDataConfig_SwagUp)), 
    Category("Regression")]
    public void LOZ_Swag(string SearchItem, string[] LegendOfZelda_SWAG)
    {
        HomePage homePage = new HomePage(getDriver());
        homePage.NavigateURL();

        SearchResultPage searchResultPage = new SearchResultPage(getDriver());
        for (int i = 0; i < LegendOfZelda_SWAG.Length; i++)
        {
            var product = SearchItem + " " + LegendOfZelda_SWAG[i];
            Console.WriteLine(product);
            homePage.Search_Item(product);
            searchResultPage.AddProduct();
            searchResultPage.AddToCart();
        }

        searchResultPage.ProceedtoCheckout();

        ////TODO: Go through each row and validate Item exists.
        //IList<IWebElement> checkout_List = _driver.Value.FindElements(By.CssSelector("div.sc-list-body")); 
        //for (int i = 0; i < checkout_List.Count; i++)
        //{
        //    checkout_Lists[i] = checkout_List[i].Text;
        //}

        //Assert.AreEqual(checkout_List, checkout_Lists);
    }

    // *** TestCaseSource *** //
    public static IEnumerable<TestCaseData> TCDataConfig_SingleItem()
    {
        yield return new TestCaseData(
            getJsonData().TestData_extractJson("SearchItem"));
    }
    public static IEnumerable<TestCaseData> TCDataConfig_SwagUp()
    {
        yield return new TestCaseData(
            getJsonData().TestData_extractJson("SearchItem"),
            getJsonData().TestData_extractJsonArray("LegendOfZelda_SWAG"));
    }
}