using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using AppMillionTest.Utilities;
using AppMillionTest.Drivers;
using AppMillionTest.Locators;

namespace AppMillionTest.Pages
{
    /// <summary>
    /// Page object for the lead detail screen.
    /// </summary>
    public class LeadDetailPage : CommonMethods
    {
        /// <summary>
        /// Initializes a new instance of the LeadDetailPage class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public LeadDetailPage(IOSDriver driver) : base(IOSDriverFactory.Driver){}
      
        /// <summary>
        /// Clicks the add activity icon to create a new activity.
        /// </summary>
        public void ClickAddActivityIcon()
        {
            Thread.Sleep(14000); // Short wait before interacting

            Click(LeadDetailLocators.AddActivityIcon);

            
        }

        /// <summary>
        /// Gets the text of the latest note.
        /// </summary>
        /// <returns>The text content of the latest note.</returns>
        public string GetLatestNoteText()
        {
            return GetElementText(LeadDetailLocators.LatestNotePredicate);
        }
    }
}
