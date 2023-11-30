using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Interfaces;

namespace RedBus.Utilities
{
    public class BaseClass
    {
        public IWebDriver driver;
        ExtentReports extent;
        ExtentTest test;
        String browserName;
        [OneTimeSetUp] 
        public void Setup() 
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath=projectDirectory + "//report.html";
            var htmlReporter=new ExtentHtmlReporter(reportPath);
            extent=new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("HostName", "Localhost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Praveen");
        }
        [SetUp]
        public void StartBrowser()
        {
            
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];
            if(browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
            driver.Url = "https://www.redbus.in/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }
        public IWebDriver getDriver()
        {
            return driver;
        }
        [TearDown]
        public void AfterTest()
        {
            var status=TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace=TestContext.CurrentContext.Result.StackTrace;
            DateTime time=DateTime.Now;
            String filename = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if(status==TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreenshot(driver, filename));
                test.Log(Status.Fail,"test failed with logtrace"+stackTrace);
            }
            else if(status==TestStatus.Passed)
            {

            }
            extent.Flush();
            driver.Quit();
        }
        public MediaEntityModelProvider captureScreenshot(IWebDriver driver,String screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot=ts.GetScreenshot().AsBase64EncodedString;
           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();

        }
    }
}
