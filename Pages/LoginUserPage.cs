using AppMillionTest.Drivers;
using AppMillionTest.Locators;
using AppMillionTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using Reqnroll.Formatters.PayloadProcessing.Cucumber;
using System;

namespace AppMillionTest.Pages
{
    public class LoginUserPage : CommonMethods
    {

        public LoginUserPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        public void IngresarNombreDeUsuario(string username)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var usernameField = wait.Until(d => d.FindElement(LoginUserLocators.UsernameInput));
            usernameField.Clear();
            usernameField.SendKeys(username.Substring(0, 1));

            // Enviar el resto de la cadena de golpe
            if (username.Length > 1)
            {
                usernameField.SendKeys(username.Substring(1));
            }

        }

        public void ClickContinueButton()
        {
            Click(LoginUserLocators.ContinueButton);
        }

        public bool IsLoginScreenVisible()
        {            
            return IsElementVisible(LoginUserLocators.UsernameInput);
             
        }
    }
}
