using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

using AppMillionTest.Drivers;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AppMillionTest.Utilities;
using AppMillionTest.Locators;

namespace AppMillionTest.Pages
{
    /// <summary>
    /// Page object for the user profile and settings screen.
    /// </summary>
    public class UserPage : CommonMethods
    {
        /// <summary>
        /// Initializes a new instance of the UserPage class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public UserPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        /// <summary>
        /// Clicks the sign out option in the user menu.
        /// </summary>
        public void ClickSignOutOption()
        {
            Click(UserLocators.SignOutOption);


        }

        /// <summary>
        /// Clicks the Yes button on the confirmation dialog.
        /// </summary>
        public void ClickYesOption()
        {
            ClickByCoordinates(315, 533);
        }

        /// <summary>
        /// Clicks the change status option in the user menu.
        /// </summary>
        public void ClickChangeStatusOption()
        {
            Click(UserLocators.ChangeStatusIcon);
            Thread.Sleep(500);
        }

        /// <summary>
        /// Gets the current user status text.
        /// </summary>
        /// <returns>The current status text.</returns>
        public string GetStatusText()
        {
            var statusText = GetElementText(UserLocators.StatusText);
            return statusText;
        }

        /// <summary>
        /// Changes the user status and returns the new status.
        /// </summary>
        /// <returns>The new status text after the change.</returns>
        public string ChangeUserStatus()
        {
            var currentStatus = GetStatusText();

            ClickChangeStatusOption();
            var newStatus = GetStatusText();

            return newStatus;
        }




    }
}

