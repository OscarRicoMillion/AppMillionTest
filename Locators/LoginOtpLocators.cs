using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for OTP input.
    /// </summary>
    public static class LoginOtpLocators
    {
        public static readonly By OtpContainer = MobileBy.IosClassChain("**/XCUIElementTypeOther[`visible == 1`]");
    }
}
