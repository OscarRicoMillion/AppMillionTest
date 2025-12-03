using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace AppMillionTest.Pages
{
    public class LoginOtpPage
    {
        private readonly IOSDriver driver;
        public LoginOtpPage(IOSDriver driver)
        {
            this.driver = driver;
        }

        private By AboutOption => MobileBy.AccessibilityId("About");


        public void OpenInformationSection()
        {
            driver.FindElement(AboutOption).Click();
        }

        public void IngresarOtp(string codigo)
        {
            var otpBoxes = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeOther[`visible == 1`]"));



            otpBoxes.SendKeys(codigo.Substring(0, 1));

            // Enviar el resto de la cadena de golpe
            if (codigo.Length > 1)
            {
                otpBoxes.SendKeys(codigo.Substring(1));
            }
        }
    }
}
