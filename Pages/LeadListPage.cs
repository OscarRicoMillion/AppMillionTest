using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

namespace AppMillionTest.Pages
{
    public class LeadListPage
    {
        private readonly IOSDriver driver;
        public LeadListPage(IOSDriver driver)
        {
            this.driver = driver;
        }

        public bool IconUserIsPresent()
        {
            var IconUser = driver.FindElement(MobileBy.AccessibilityId("Profile"));
            return IconUser.Displayed;
        }

        public void ClickUserIcon()
        {
            var UserIcon = driver.FindElement(MobileBy.AccessibilityId("Profile"));
            UserIcon.Click();
        }

        public void ClickFirstLead()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("get_LeadDetail")));
            element.Click();

        }
    }
}
