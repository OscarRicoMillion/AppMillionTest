using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using Allure.NUnit; // if you rely on Reqnroll utilities

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    [AllureNUnit]
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
