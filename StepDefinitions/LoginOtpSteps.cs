using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium; // si usas las utilidades de Reqnroll

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class LoginOtpSteps
    {
        private readonly LoginOtpPage loginOtpPage;


        public LoginOtpSteps()
        {
            var driver = IOSDriverFactory.Driver;      
            loginOtpPage = new LoginOtpPage(driver);

        }

        [When(@"ingresa el OTP ""(.*)""")]
        public void WhenIngresaElOTP(string codigo)
        {
            loginOtpPage.IngresarOtp(codigo);
        }

       


    }
}
