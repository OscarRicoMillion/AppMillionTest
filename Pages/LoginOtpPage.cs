using AppMillionTest.Drivers;
using AppMillionTest.Utilities;
using AppMillionTest.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

namespace AppMillionTest.Pages
{
    /// <summary>
    /// Page object for the OTP entry screen.
    /// </summary>
    public class LoginOtpPage : CommonMethods
    {
        /// <summary>
        /// Initializes a new instance of the LoginOtpPage class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public LoginOtpPage(IOSDriver driver) : base(IOSDriverFactory.Driver) { }

        /// <summary>
        /// Enters the OTP code into the input field.
        /// </summary>
        /// <param name="code">The OTP code to enter.</param>
        public void EnterOtp(string code)
        {
            // Make sure the OTP container is visible before typing
            if (!IsElementVisible(LoginOtpLocators.Otpcontainer))
            {

                throw new NoSuchElementException("OTP container is not visible.");

            }

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var Otp = wait.Until(d => d.FindElement(LoginOtpLocators.OtpInput));
            Otp.Clear();
            Otp.SendKeys(code.Substring(0, 1));

            // Send the rest of the string at once
            if (code.Length > 1)
            {
                Otp.SendKeys(code.Substring(1));
            }

        }
    }
}
