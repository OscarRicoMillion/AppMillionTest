using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using AppMillionTest.Utilities;
using AppMillionTest.Drivers;
using AppMillionTest.Locators;

namespace AppMillionTest.Pages
{
    /// <summary>
    /// Page object for the activity dashboard screen.
    /// </summary>
    public class ActivityDashBoardPage : CommonMethods
    {
        /// <summary>
        /// Initializes a new instance of the ActivityDashBoardPage class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public ActivityDashBoardPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        /// <summary>
        /// Selects the note option from the activity menu.
        /// </summary>
        public void SelectNoteOption()
        {
            Click(ActivityDashBoardLocators.NoteOption);
        }

        /// <summary>
        /// Enters text into the note input field.
        /// </summary>
        /// <param name="note">The note text to enter.</param>
        public void EnterNoteText(string note)
        {
            SendKeys(ActivityDashBoardLocators.NoteInput, note);
        }

        /// <summary>
        /// Clicks the Save Notes button.
        /// </summary>
        public void ClickSaveNotes()
        {
            Thread.Sleep(2000);
            ClickByCoordinates(228, 588);
        }       






    }
}
