using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for Lead detail screen.
    /// </summary>
    public static class LeadDetailLocators
    {
        public static readonly By AddActivityIcon = MobileBy.AccessibilityId("TEST_ID_DETAIL_LEAD_ADD_ACTIVITY");
        public static readonly By LatestNotePredicate = MobileBy.IosNSPredicate("name CONTAINS 'NOTE'");
    }
}
