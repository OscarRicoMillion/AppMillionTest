using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using System;

namespace AppMillionTest.Pages
{
    public class LoginUserPage
    {
        private readonly IOSDriver driver;
        public LoginUserPage(IOSDriver driver)
        {
            this.driver = driver;
        }
        
        public void IngresarNombreDeUsuario(string username)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var usernameField = wait.Until(d => d.FindElement(MobileBy.AccessibilityId("TEST_ID_LOGIN_EMAIL_INPUT")));            
            usernameField.Clear();
            Thread.Sleep(120);
            usernameField.SendKeys(username);            
        }

        public void ClickContinueButton()
        {
            var continueButton = driver.FindElement(MobileBy.AccessibilityId("Continue"));
            continueButton.Click();
        }

        public bool IsLoginScreenVisible(int timeoutSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
                var el = wait.Until(d => d.FindElement(MobileBy.AccessibilityId("TEST_ID_LOGIN_EMAIL_INPUT")));
                return el != null && el.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
