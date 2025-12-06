using AppMillionTest.Drivers;
using AppMillionTest.Locators;
using AppMillionTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

namespace AppMillionTest.Pages
{
    /// <summary>
    /// Page object for the lead list screen.
    /// </summary>
    public class LeadListPage : CommonMethods
    {
        /// <summary>
        /// Initializes a new instance of the LeadListPage class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public LeadListPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        /// <summary>
        /// Checks if the user icon is present on the screen.
        /// </summary>
        /// <returns>True if the user icon is present, false otherwise.</returns>
        public bool IconUserIsPresent()
        {
            return IsElementVisible(LeadListLocators.UserIcon);
        }

        /// <summary>
        /// Clicks the user icon on the lead list screen.
        /// </summary>
        public void ClickUserIcon()
        {
            Click(LeadListLocators.UserIcon);
        }

        /// <summary>
        /// Clicks the first lead in the list.
        /// </summary>
        public void ClickFirstLead()
        {
            Thread.Sleep(2000); 
            Click(LeadListLocators.FirstLead);

        }
    }
}
