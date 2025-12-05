using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

using AppMillionTest.Drivers;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AppMillionTest.Utilities;

namespace AppMillionTest.Pages
{
    public class UserPage : CommonMethods
    {


        public UserPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        public void ClickSignOutOption()
        {
            Click(MobileBy.AccessibilityId("TEST_ID_PROFILE_LOG_OUT_BTN_LETTER"));


        }

        public void ClickYesOption()
        {
            ClickByCoordinates(315, 533);
        }

        public void ClickChangeStatusOption()
        {

            Click(MobileBy.AccessibilityId(""));
        }

        public string GetStatusText()
        {
            var statusText = GetElementText(MobileBy.XPath("//XCUIElementTypeScrollView//XCUIElementTypeOther[3]//XCUIElementTypeStaticText"));
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

