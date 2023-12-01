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
            IWebElement image = p.getImageButton();
            IWebElement v = p.getViewAllButton();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)",image);
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(v));
            v.Click();
            p.getIButton().Click();
            PrintValues();
            p.getRButton().Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(3000);
            p.getPage3().Click();
            PrintValues();
            p.getAButton().Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(3000);
            p.getPage3().Click();
            PrintValues();
        }
        public void PrintValues()
        {
            IList<IWebElement> element = driver.FindElements(By.XPath("//li[@class='D113_item']"));
            int i = 0;
            foreach (IWebElement ele in element)
            {
                String busname = ele.Text;
                TestContext.Progress.WriteLine(busname);
                i++;
            }
        }
    }
}


