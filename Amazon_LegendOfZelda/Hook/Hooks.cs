using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_LegendOfZelda.Hook
{
    public class Hooks
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
