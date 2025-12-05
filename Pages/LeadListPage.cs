using AppMillionTest.Drivers;
using AppMillionTest.Locators;
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
            return IsElementVisible(LeadListLocators.UserIcon);
        }

        public void ClickUserIcon()
        {
            Click(LeadListLocators.UserIcon);
        }

        public void ClickFirstLead()
        {
            Thread.Sleep(2000); 
            Click(LeadListLocators.FirstLead);

        }
    }
}
