using AppMillionTest.Drivers;
using AppMillionTest.Locators;
using AppMillionTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using Reqnroll.Formatters.PayloadProcessing.Cucumber;
using System;

namespace AppMillionTest.Pages
{
    /// <summary>
    /// Page object for the login username screen.
    /// </summary>
    public class LoginUserPage : CommonMethods
    {
        /// <summary>
        /// Initializes a new instance of the LoginUserPage class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public LoginUserPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        /// <summary>
        /// Enters the username into the login field.
        /// </summary>
        /// <param name="username">The username to enter.</param>
        public void EnterUsername(string username)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var usernameField = wait.Until(d => d.FindElement(LoginUserLocators.UsernameInput));
            usernameField.Clear();
            usernameField.SendKeys(username.Substring(0, 1));

            // Send the rest of the string in one shot
            if (username.Length > 1)
            {
                usernameField.SendKeys(username.Substring(1));
            }

        }

        /// <summary>
        /// Clicks the Continue button on the login screen.
        /// </summary>
        public void ClickContinueButton()
        {
            Click(LoginUserLocators.ContinueButton);
        }

        /// <summary>
        /// Checks if the login screen is currently visible.
        /// </summary>
        /// <returns>True if the login screen is visible, false otherwise.</returns>
        public bool IsLoginScreenVisible()
        {            
            return IsElementVisible(LoginUserLocators.UsernameInput);
             
        }
    }
}
