using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using AppMillionTest.Utilities;
using AppMillionTest.Drivers;

namespace AppMillionTest.Pages
{
    public class ActivityDashBoardPage : CommonMethods
    {


        public ActivityDashBoardPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }


        public void SelectNoteOption()
        {
            Click(MobileBy.AccessibilityId("Note"));


        }

        public void EnterNoteText(string note)
        {
            SendKeys(MobileBy.AccessibilityId("Write a note"), note);

        }

        public void ClickSaveNotes()
        {

            Thread.Sleep(2000);

            ClickByCoordinates(228, 588);

        }       






    }
}
