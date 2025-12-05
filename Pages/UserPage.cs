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
    public class UserPage : CommonMethods
    {


        public UserPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        public void ClickSignOutOption()
        {
            Click(UserLocators.SignOutOption);


        }

        public void ClickYesOption()
        {
            ClickByCoordinates(315, 533);
        }

        public void ClickChangeStatusOption()
        {

            Click(UserLocators.ChangeStatusIcon);
        }

        public string GetStatusText()
        {
            var statusText = GetElementText(UserLocators.StatusText);
            return statusText;
        }

        public string ChangeUserStatus()
        {
            var currentStatus = GetStatusText();

            ClickChangeStatusOption();
            var newStatus = GetStatusText();

            return newStatus;
        }




    }
}

