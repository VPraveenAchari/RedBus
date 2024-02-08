using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.UI;
using RedBus.PageObject;

namespace RedBus.Utilities
{
    public class BaseClass
    {
        public static IWebDriver driver;
        ExtentReports extent;
        ExtentTest test;
        string browserName;
       
        [OneTimeSetUp] 
        public void Setup() 
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath=projectDirectory + "//Report.html";
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
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
        public static IWebDriver getDriver()
        {
            return driver;
        }
        public void Access()
        {
            POMClass p = new POMClass(getDriver());
            IWebElement image = p.ImageButton;
            IWebElement v = p.ViewAllButton;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", image);
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(v));
            v.Click();
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
                IList<IWebElement> element = driver.FindElements(By.XPath("//li[@class='D113_item']"));
                int i = 0;
                foreach (IWebElement ele in element)
                {
                    String busname = ele.Text;
                    test.Log(Status.Pass, busname);
                    i++;
                }
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
