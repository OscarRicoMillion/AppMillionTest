using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for Lead list interactions.
    /// </summary>
    public static class LeadListLocators
    {
        public static readonly By UserIcon = MobileBy.AccessibilityId("Profile");
        public static readonly By FirstLead = MobileBy.AccessibilityId("get_LeadDetail"); 

        
    }
}
