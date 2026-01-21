using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.Locators
{
    /// <summary>
    /// Selectors for OTP view.
    /// </summary>
    public static class LoginOtpLocators
    {   
        public static readonly By Otpcontainer = MobileBy.AccessibilityId("TEST_ID_VERIFICATION_CODE_CONTAINER");
        //public static readonly By OtpInput = MobileBy.IosClassChain("**/XCUIElementTypeOther[`visible == 1`]");

        public static readonly By OtpInput = MobileBy.AccessibilityId("TEST_ID_VERIFICATION_CODE_VIEW_INPUT_CODE0");
    }
}
