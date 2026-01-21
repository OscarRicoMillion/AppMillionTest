using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for user/profile actions.
    /// </summary>
    public static class UserLocators
    {
        public static readonly By SignOutOption = MobileBy.AccessibilityId("TEST_ID_PROFILE_LOG_OUT_BTN");
        public static readonly By ChangeStatusIcon = MobileBy.AccessibilityId("TEST_ID_PROFILE_STATUS_SWITCH");
        public static readonly By StatusText = MobileBy.XPath("//XCUIElementTypeScrollView//XCUIElementTypeOther[3]//XCUIElementTypeStaticText");
    }
}
