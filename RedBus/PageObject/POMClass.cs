using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RedBus.Utilities;

namespace RedBus.PageObject
{
    public class POMClass
    {
        IWebDriver driver;
        public POMClass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebElement ImageButton => driver.FindElement(By.XPath("//img[@title='UPSRTC Bus Online Booking']"));
        public IWebElement ViewAllButton => driver.FindElement(By.XPath("//a[@class='PrivatePartners__ViewAll-sc-2695bf-2 dmxFif']"));
        public IWebElement IButton => driver.FindElement(By.XPath("//a[text()='I']"));
        public IWebElement RButton => driver.FindElement(By.XPath("//a[text()='R']"));
        public IWebElement AButton => driver.FindElement(By.XPath("//a[text()='A']"));
        public IWebElement Page3 => driver.FindElement(By.XPath("//a[text()='3']"));
    }
}
