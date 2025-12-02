using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace AppMillionTest.Pages
{
    public class ActivityDashBoardPage
    {
        private readonly IOSDriver driver;

        public ActivityDashBoardPage(IOSDriver driver)
        {
            this.driver = driver;
        }

        public void SelectNoteOption()
        {
            var noteOption = driver.FindElement(MobileBy.AccessibilityId("Note"));
            noteOption.Click();
        }

        public void EnterNoteText(string note)
        {
            var noteInput = driver.FindElement(MobileBy.AccessibilityId("Write a note"));
            noteInput.Clear();
            noteInput.SendKeys(note);
            Thread.Sleep(1000);
        }

        public void ClickSaveNotes()
        {

            Thread.Sleep(2000);

            var tapArgs = new Dictionary<string, object>
            {
                { "x", 228 }, 
                { "y", 588 }
            };

            driver.ExecuteScript("mobile: tap", tapArgs);

        }

        public bool IsNoteCreatedWithText(string note, int timeoutSeconds = 6)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                var el = wait.Until(d => d.FindElement(MobileBy.AccessibilityId("NOTE_TEXT")));
                return el != null && el.Text.Trim() == note;
            }
            catch
            {
                return false;
            }
        }

        public bool IsCreationTimestampVisible(int timeoutSeconds = 6)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                var el = wait.Until(d => d.FindElement(MobileBy.AccessibilityId("NOTE_TIMESTAMP")));
                return el != null && el.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsAuthorVisible(string author, int timeoutSeconds = 6)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                var el = wait.Until(d => d.FindElement(MobileBy.AccessibilityId("NOTE_AUTHOR")));
                return el != null && el.Text.Contains(author);
            }
            catch
            {
                return false;
            }
        }
    }
}
