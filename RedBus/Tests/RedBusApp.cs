using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RedBus.PageObject;
using RedBus.Utilities;

namespace RedBus.Tests
{
    public class RedBusApp:BaseClass
    {
        [Test]
        public void RedBusTest()
        {
            POMClass p = new POMClass(getDriver());
            IWebElement element = p.getImageButton();
            IWebElement e = p.getViewAllButton();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(e));
            e.Click();
            p.getIButton().Click();
            p.getRButton().Click();
            p.getAButton().Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(5000);
            p.getPage3().Click();
/*            //li[@class='D113_item']
            IList<IWebElement> list = driver.FindElements(By.XPath("//li[@class='D113_item']"));
            foreach (IWebElement ele in list)
            {
                TestContext.Progress.WriteLine(ele);
            }*/
        }
        [Test]
        public void RedBusTest1()
        {
            POMClass p = new POMClass(getDriver());
            IWebElement element = p.getImageButton();
            IWebElement e = p.getViewAllButton();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", element);
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(e));
            e.Click();
            p.getIButton().Click();
            p.getRButton().Click();
            p.getAButton().Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            //Thread.Sleep(5000);
            p.getPage3().Click();
            /*//li[@class='D113_item']
            IList<IWebElement> list = driver.FindElements(By.XPath("//li[@class='D113_item']"));
            foreach (IWebElement ele in list)
            {
                TestContext.Progress.WriteLine(ele);
            }*/
        }
    }
}
