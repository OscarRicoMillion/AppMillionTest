using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using AppMillionTest.Utilities;
using AppMillionTest.Drivers;
using AppMillionTest.Locators;

namespace AppMillionTest.Pages
{
    public class LeadDetailPage : CommonMethods
    {
        

        public LeadDetailPage(IOSDriver driver) : base(IOSDriverFactory.Driver){}
      
        public void ClickAddActivityIcon()
        {
            Thread.Sleep(14000); // Espera breve antes de interactuar

            Click(LeadDetailLocators.AddActivityIcon);

            
        }

        public string GetLatestNoteText()
        {
            return GetElementText(LeadDetailLocators.LatestNotePredicate);
        }
    }
}
