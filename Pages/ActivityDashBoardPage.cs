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
    public class ActivityDashBoardPage : CommonMethods
    {


        public ActivityDashBoardPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }


        public void SelectNoteOption()
        {
            Click(ActivityDashBoardLocators.NoteOption);


        }

        public void EnterNoteText(string note)
        {
            SendKeys(ActivityDashBoardLocators.NoteInput, note);

        }

        public void ClickSaveNotes()
        {

            Thread.Sleep(2000);

            ClickByCoordinates(228, 588);

        }       






    }
}
