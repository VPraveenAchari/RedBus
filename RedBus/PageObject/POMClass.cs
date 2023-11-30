using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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
        [FindsBy(How = How.XPath, Using = "//img[@title='UPSRTC Bus Online Booking']")]
        IWebElement Image;//e
        [FindsBy(How = How.XPath, Using = "//a[@class='PrivatePartners__ViewAll-sc-2695bf-2 dmxFif']")]
        IWebElement ViewAllButton;//element
        [FindsBy(How = How.XPath, Using = "//ul[@class='D112_ul']/descendant::a[9]")]
        IWebElement IButton;
        [FindsBy(How = How.XPath, Using = "//ul[@class='D112_ul']/descendant::a[18]")]
        IWebElement RButton;
        [FindsBy(How = How.XPath, Using = "//ul[@class='D112_ul']/descendant::a[1]")]
        IWebElement AButton;
        [FindsBy(How = How.XPath, Using = "//a[text()='3']")]
        IWebElement Page3;

        public IWebElement getImageButton() { return Image; }
        public IWebElement getViewAllButton() { return ViewAllButton; }
        public IWebElement getIButton() { return IButton; }
        public IWebElement getRButton() { return RButton; }
        public IWebElement getAButton() { return AButton; }
        public IWebElement getPage3() { return Page3; }
    }
}
