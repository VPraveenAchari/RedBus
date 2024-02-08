using OpenQA.Selenium;
using RedBus.PageObject;
using RedBus.Utilities;

namespace RedBus.Tests
{
    public class RedBusApp:BaseClass
    {
        [Test]
        public void IOperators()
        {
            Access();
            POMClass p = new POMClass(getDriver());
            p.IButton.Click();
        }
        [Test]
        public void ROperators()
        {
            Access();
            POMClass p = new POMClass(getDriver());
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            p.RButton.Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(3000);
            p.Page3.Click();
        }
        [Test]
        public void AOperators()
        {
            Access();
            POMClass p = new POMClass(getDriver());
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            p.AButton.Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(3000);
            p.Page3.Click();
        }
    }
}


