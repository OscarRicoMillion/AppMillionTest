using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for the activity dashboard (notes) flow.
    /// </summary>
    public static class ActivityDashBoardLocators
    {
        public static readonly By NoteOption = MobileBy.AccessibilityId("Note");
        public static readonly By NoteInput = MobileBy.AccessibilityId("Write a note");
    }
}
