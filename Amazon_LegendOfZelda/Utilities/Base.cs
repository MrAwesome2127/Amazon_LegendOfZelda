using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon_LegendOfZelda.Utilities
{
    [SetUpFixture]
    public class Base
    {
        //Terminal Command:
        //dotnet test Amazon_LegendOfZelda.csproj
        //--filter TestCategory=Regression
        //--TestRunParameters.Parameters\(name=\"browserName\",value=\"Chrome\")
        //TODO create a "browserName" variable in ADO that determines the Browser Type.

        //Thread allows Parallel testing. 
        public ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();
        string BrowserName;

        public ExtentTest _Test;
        public ExtentReports _Extent;
        [OneTimeSetUp] 
        public void OneTimeSetup() //creating reporting file repository
        {
            //ExtentHtmlReporter is retired in ExtentReport 5+
            //ExtentSparkReporter is the new naming convention.
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//Test_Reports//index.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            _Extent = new ExtentReports();
            _Extent.AttachReporter(htmlReporter);
            _Extent.AddSystemInfo("Environment","Production");
            _Extent.AddSystemInfo("Testsite", "Amazon");
        }
        
        [BeforeScenario]
        public void Setup()
        {
            //services
            //    .AddSingleton<IRestLibrary, RestLibrary>()
            //    .AddScoped<IRestBuilder, RestBuilder>()
            //    .AddScoped<IRestFactory, RestFactory>();

            _Test = _Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            BrowserName = TestContext.Parameters["browserName"];
            if (BrowserName == null)
            {
                BrowserName = ConfigurationManager.AppSettings["browser"];
            }
            InitializeBrowser(BrowserName);
        }

        public IWebDriver getDriver()
        {
            Setup();
            return _driver.Value;
        }

        public void InitializeBrowser(string BrowserName)
        {
            switch (BrowserName.ToLower())
            {
                case "chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    _driver.Value = new ChromeDriver();
                    break;
                case "edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    _driver.Value = new EdgeDriver();
                    break;
                case "fireFox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver.Value = new FirefoxDriver();
                    break;
            }
        }

        public static JsonReader getJsonData()
        {
            return new JsonReader();
        }

        [TearDown]
        public void TearDown()
        {
            DateTime time = DateTime.Now;
            string fileName = "ScreenShot_" + time.ToString("h_mm_ss") + ".png";
            var TestStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var TestStackTrace = TestContext.CurrentContext.Result.StackTrace;

            if (TestStatus == TestStatus.Failed)
            {
                _Test.Fail("Test Failed", CaptureScreenshot(_driver.Value, fileName));
                _Test.Log(Status.Fail,"Test failed, included logtrace " + TestStackTrace);
            }
            else if (TestStatus == TestStatus.Passed)
            {
                _Test.Pass("Test Passed", CaptureScreenshot(_driver.Value, fileName));
                _Test.Log(Status.Pass, "Test passed, included logtrace " + TestStackTrace);
                _driver.Value.Quit();
            }
            _Extent.Flush();
        }

        //MediaEntityModelProvider is retired in ExtentReport 5+
        //Media is the new naming convention.
        public static Media CaptureScreenshot(IWebDriver _driver, string screenShotName)
        {
            ITakesScreenshot sShot = (ITakesScreenshot)_driver;
            var screenShot = sShot.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
        }
    }
}
