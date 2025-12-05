using AppMillionTest.Drivers;
using AppMillionTest.Utilities;
using AppMillionTest.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace AppMillionTest.Pages
{
    public class LoginOtpPage : CommonMethods
    {

        public LoginOtpPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        public void IngresarOtp(string codigo)
        {
            var otpBoxes = Driver.FindElement(LoginOtpLocators.OtpContainer);

            otpBoxes.SendKeys(codigo.Substring(0, 1));

            // Enviar el resto de la cadena de golpe
            if (codigo.Length > 1)
            {
                otpBoxes.SendKeys(codigo.Substring(1));
            }
        }
    }
}
