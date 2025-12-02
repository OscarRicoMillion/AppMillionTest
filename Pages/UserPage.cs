using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

using AppMillionTest.Drivers;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AppMillionTest.Pages
{
    public class UserPage
    {
        private readonly IOSDriver driver;

        public UserPage(IOSDriver driver)
        {
            this.driver = driver;
        }
        public void ClickSignOutOption()
        {
            var SignOutOption = driver.FindElement(MobileBy.AccessibilityId("TEST_ID_PROFILE_LOG_OUT_BTN_LETTER"));
            SignOutOption.Click();


        }

        public void ClickYesOption()
        {
            int x = 315;
            int y = 533;

            // Inicializa Actions (asegúrate de que el driver es AppiumDriver<AppiumWebElement>)
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);

            // Realiza el Tap
            actions.MoveToLocation(x, y).Click().Perform();

            Console.WriteLine($"✅ Clic simulado en coordenadas X:{x}, Y:{y}.");
        }

        public void ClickChangeStatusOption()
        {           
            var changeStatus = driver.FindElement(MobileBy.AccessibilityId(""));
            changeStatus.Click();    
        }

        public string  GetStatusText(string expectedStatus)
        {
            var changeStatus = driver.FindElement(MobileBy.XPath("//XCUIElementTypeScrollView//XCUIElementTypeOther[3]//XCUIElementTypeStaticText"));
            string  StatusText = changeStatus.Text;
             Console.WriteLine($"✅ El ustatus es '{StatusText}').");
            return StatusText;
        }

        

        
    }
}

