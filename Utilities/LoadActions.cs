using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AppMillionTest.Utilities
{
    /// <summary>
    /// Helper class for validating loading indicators during test execution.
    /// </summary>
    public class LoadActions
    {
        private readonly IOSDriver driver;

        /// <summary>
        /// Initializes a new instance of the LoadActions class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public LoadActions(IOSDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Validates that the loading icon appears and then disappears within the timeout period.
        /// </summary>
        /// <returns>True if the icon appeared and then disappeared, false otherwise.</returns>
        /// <exception cref="WebDriverTimeoutException">Thrown when the icon does not appear or disappear on time.</exception>
        public bool ValidateLoadingIcon()
        {

            string iconAccessibilityId = "LoadingPress";
            TimeSpan timeout = TimeSpan.FromSeconds(10); // Maximum time allowed for validation

            // Initialize the WebDriverWait
            var wait = new WebDriverWait(driver, timeout);

            
            By iconLocator = MobileBy.AccessibilityId(iconAccessibilityId);

            try
            {
                var iconElementDisplay = wait.Until(ExpectedConditions.ElementIsVisible(iconLocator));

                Console.WriteLine("✅ 'LoadingPress' icon found (log out started).");


                var iconelementNotDisplayed = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(iconLocator));
                Console.WriteLine("✅ 'LoadingPress' icon disappeared (log out finished).");

                // Confirm that the icon first appeared and then disappeared
                var wasVisible = iconElementDisplay != null;
                return wasVisible && iconelementNotDisplayed;

            }
            catch (WebDriverTimeoutException)
            {
              
                Console.WriteLine($"❌ Validation failed: Icon '{iconAccessibilityId}' did not appear or disappear on time.");
                throw; // Re-throw so the test fails visibly
            }
        }

        
    }
}