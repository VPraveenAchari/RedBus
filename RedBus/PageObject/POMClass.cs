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
        [FindsBy(How = How.XPath, Using = Constants.Image)]
        IWebElement Image;
        [FindsBy(How = How.XPath, Using = Constants.ViewAllButton)]
        IWebElement ViewAllButton;
        [FindsBy(How = How.XPath, Using = Constants.IButton)]
        IWebElement IButton;
        [FindsBy(How = How.XPath, Using = Constants.RButton)]
        IWebElement RButton;
        [FindsBy(How = How.XPath, Using = Constants.AButton)]
        IWebElement AButton;
        [FindsBy(How = How.XPath, Using = Constants.Page3)]
        IWebElement Page3;

        public IWebElement getImageButton() { return Image; }
        public IWebElement getViewAllButton() { return ViewAllButton; }
        public IWebElement getIButton() { return IButton; }
        public IWebElement getRButton() { return RButton; }
        public IWebElement getAButton() { return AButton; }
        public IWebElement getPage3() { return Page3; }
    }
}
