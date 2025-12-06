using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium; // if you rely on Reqnroll utilities

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

        [When("enters the OTP \"(.*)\"")]
        public void WhenEntersTheOtp(string code)
        {               
            loginOtpPage.EnterOtp(code);
        }
    }
}
