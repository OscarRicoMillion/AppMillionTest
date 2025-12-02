using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace AppMillionTest.Utilities
{
    public class CommonMethods
    {

         private readonly IOSDriver driver; 

        public CommonMethods(IOSDriver driver)
        {
            this.driver = driver;
        }

        public void goBack()
        {
            var backButton = driver.FindElement(MobileBy.AccessibilityId("TEST_ID_DETAIL_LEAD_GO_BACK"));
            backButton.Click();
        }
        
    }
    
}