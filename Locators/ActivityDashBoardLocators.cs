using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for the activity dashboard (notes) flow.
    /// </summary>
    public static class ActivityDashBoardLocators
    {
        /// <summary>
        /// Locator for selecting an activity option. NOTE/TASK
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public static By ActivityOption(string option) => MobileBy.AccessibilityId(option);

        public static readonly By NoteInput = MobileBy.AccessibilityId("Write a note");
    }
}
