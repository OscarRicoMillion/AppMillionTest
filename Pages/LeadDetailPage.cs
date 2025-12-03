using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using AppMillionTest.Utilities;

namespace AppMillionTest.Pages
{
    public class LeadDetailPage
    {
        private readonly IOSDriver driver;

        public LeadDetailPage(IOSDriver driver)
        {
            this.driver = driver;
         
        }

        public void ClickAddActivityIcon()
        {
            Thread.Sleep(14000); // Espera breve antes de interactuar

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var addIcon = wait.Until(d => d.FindElement(MobileBy.AccessibilityId("TEST_ID_DETAIL_LEAD_ADD_ACTIVITY")));
            addIcon.Click();
        }

        public string GetLatestNoteText(int timeoutSeconds = 6)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                var el = wait.Until(d => d.FindElement(MobileBy.IosNSPredicate("name CONTAINS 'NOTE'")));
                return el?.Text?.Trim() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
