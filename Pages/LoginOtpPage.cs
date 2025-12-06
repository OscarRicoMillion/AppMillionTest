using AppMillionTest.Drivers;
using AppMillionTest.Utilities;
using AppMillionTest.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

namespace AppMillionTest.Pages
{
    public class LoginOtpPage : CommonMethods
    {

        public LoginOtpPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        public void IngresarOtp(string codigo)
        {
            // Verificar que el contenedor de OTP esté visible
            if (!IsElementVisible(LoginOtpLocators.Otpcontainer))
            {

                throw new NoSuchElementException("El contenedor de OTP no está visible.");

            }

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var Otp = wait.Until(d => d.FindElement(LoginOtpLocators.OtpInput));
            Otp.Clear();
            Otp.SendKeys(codigo.Substring(0, 1));

            // Enviar el resto de la cadena de golpe
            if (codigo.Length > 1)
            {
                Otp.SendKeys(codigo.Substring(1));
            }

        }
    }
}
