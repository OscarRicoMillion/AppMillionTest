using AppMillionTest.Drivers;
using AppMillionTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

namespace AppMillionTest.Pages
{
    public class LeadListPage : CommonMethods
    {

        public LeadListPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        public bool IconUserIsPresent()
        {
            return IsElementVisible(MobileBy.AccessibilityId("Profile"));
        }

        public void ClickUserIcon()
        {
            Click(MobileBy.AccessibilityId("Profile"));
        }

        public void ClickFirstLead()
        {
            Thread.Sleep(2000); 
            Click(MobileBy.AccessibilityId("get_LeadDetail"));

        }
    }
}
