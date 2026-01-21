
namespace Amazon_LegendOfZelda.Pages;

public class CommonPages
{
    IWebDriver _driver;
    public CommonPages(IWebDriver _driver)
    {
        this._driver = _driver;
    }
    public void iframeScrolling()
    {
        IWebElement framescroll = _driver.FindElement(By.Id("courses-iframe"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);
    }

    public void iSwitchToFrame()
    {
        _driver.SwitchTo().Frame("courses-iframe");
    }

    public void iSwitchBackFrame()
    {
        _driver.SwitchTo().DefaultContent();
    }
}
