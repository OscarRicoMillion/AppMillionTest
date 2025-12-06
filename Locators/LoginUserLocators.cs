using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// selectors for the Login user view.
    /// </summary>
    public static class LoginUserLocators
    {
        public static readonly By UsernameInput = MobileBy.AccessibilityId("TEST_ID_LOGIN_EMAIL_INPUT");
        public static readonly By ContinueButton = MobileBy.AccessibilityId("Continue");
    }
}
