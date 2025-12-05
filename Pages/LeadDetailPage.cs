using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using AppMillionTest.Utilities;
using AppMillionTest.Drivers;

namespace AppMillionTest.Pages
{
    public class LeadDetailPage : CommonMethods
    {
        

        public LeadDetailPage(IOSDriver driver) : base(IOSDriverFactory.Driver){}
      
        public void ClickAddActivityIcon()
        {
            Thread.Sleep(14000); // Espera breve antes de interactuar

            Click(MobileBy.AccessibilityId("TEST_ID_DETAIL_LEAD_ADD_ACTIVITY"));

            
        }

        public string GetLatestNoteText()
        {
            return GetElementText(MobileBy.IosNSPredicate("name CONTAINS 'NOTE'"));
        }
    }
}
