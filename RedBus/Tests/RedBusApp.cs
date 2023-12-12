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
            p.getIButton().Click();
        }
        [Test]
        public void ROperators()
        {
            Access();
            POMClass p = new POMClass(getDriver());
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            p.getRButton().Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(3000);
            p.getPage3().Click();
        }
        [Test]
        public void AOperators()
        {
            Access();
            POMClass p = new POMClass(getDriver());
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            p.getAButton().Click();
            js.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(3000);
            p.getPage3().Click();
        }
    }
}


