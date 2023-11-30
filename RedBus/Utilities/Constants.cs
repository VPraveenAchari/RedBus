using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RedBus.Utilities
{
    public class Constants
    {
        public const string Image = "//img[@title='UPSRTC Bus Online Booking']";
        public const string ViewAllButton = "//a[@class='PrivatePartners__ViewAll-sc-2695bf-2 dmxFif']";
        public const string IButton = "//ul[@class='D112_ul']/descendant::a[9]";
        public const string RButton = "//ul[@class='D112_ul']/descendant::a[18]";
        public const string AButton = "//ul[@class='D112_ul']/descendant::a[1]";
        public const string Page3 = "//a[text()='3']";
    }
}
