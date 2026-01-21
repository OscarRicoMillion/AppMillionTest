using System;
using System.Collections.Generic;
using Allure.Net.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AppMillionTest.Utilities
{
    /// <summary>
    /// Base class with common Selenium helper methods for iOS testing.
    /// </summary>
    public abstract class CommonMethods
    {
        /// <summary>
        /// Shared iOS driver reference reused across helpers.
        /// </summary>
        protected IOSDriver Driver { get; }
        
        /// <summary>
        /// Default wait time (seconds) used by explicit waits.
        /// </summary>
        private const int DefaultWaitSeconds = 20;

        /// <summary>
        /// Initializes a new instance of the CommonMethods class.
        /// </summary>
        /// <param name="driver">The iOS driver instance.</param>
        public CommonMethods(IOSDriver driver)
        {
            Driver = driver;
        }      

        /// <summary>
        /// Check if an element is visible on screen.
        /// </summary>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>True if the element is visible, false otherwise.</returns>
        public bool IsElementVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitSeconds));
                var el = wait.Until(d => d.FindElement(locator));
                return el != null && el.Displayed;
            }
            catch
            {
                return false;                                
            }
        }   

        /// <summary>
        /// Creates a WebDriverWait instance with the default timeout.
        /// </summary>
        /// <returns>A configured WebDriverWait instance.</returns>
        private WebDriverWait CreateWait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitSeconds));
        }

        /// <summary>
        /// Navigate back within the current view using the accessible button.
        /// </summary>
        public void GoBack()
        {
            var backButton = Driver.FindElement(MobileBy.AccessibilityId("TEST_ID_DETAIL_LEAD_GO_BACK")); // Standard back button
            backButton.Click();
        }

        /// <summary>
        /// Wait until a locator is tappable and execute the tap.
        /// </summary>
        /// <param name="locator">The locator to find the element.</param>
        public void Click(By locator)
        {
            var element = CreateWait().Until(ExpectedConditions.ElementToBeClickable(locator)); // Ready for tap
            element.Click();
        }

        /// <summary>
        /// Send text to a visible element after clearing it first.
        /// </summary>
        /// <param name="locator">The locator to find the element.</param>
        /// <param name="text">The text to send to the element.</param>
        public void SendKeys(By locator, string text)
        {
            var element = CreateWait().Until(ExpectedConditions.ElementIsVisible(locator)); // Target field
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Tap directly on absolute coordinates when no identifier is available.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public void ClickByCoordinates(int x, int y)
        {
            var scriptArgs = new Dictionary<string, object>
            {
                { "x", x },
                { "y", y },
                { "tapCount", 1 }
            };
            Driver.ExecuteScript("mobile: tap", scriptArgs);
        }

        /// <summary>
        /// Get visible text from an element with an explicit wait.
        /// </summary>
        /// <param name="locator">The locator to find the element.</param>
        /// <returns>The trimmed text content of the element.</returns>
        public string GetElementText(By locator)
        {
            var element = CreateWait().Until(ExpectedConditions.ElementIsVisible(locator));
            return element.Text?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Fetch every element that matches the locator.
        /// </summary>
        /// <param name="locator">The locator to find elements.</param>
        /// <returns>A read-only collection of matching elements.</returns>
        public IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            CreateWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            return Driver.FindElements(locator);
        }

        /// <summary>
        /// Convenience helper to retrieve elements by class name.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>A read-only collection of matching elements.</returns>
        public IReadOnlyCollection<IWebElement> GetElementsByClassName(string className)
        {
            return GetElements(MobileBy.ClassName(className));
        }

        /// <summary>
        /// Perform a short vertical swipe using the native gesture.
        /// </summary>
        public void ScrollDownOnce()
        {
            var scriptArgs = new Dictionary<string, object>
            {
                { "direction", "down" },
                { "velocity", "fast" }
            };
            Driver.ExecuteScript("mobile: swipe", scriptArgs);
        }

        /// <summary>
        /// Keep scrolling until the locator appears or the limit is reached.
        /// </summary>
        /// <param name="locator">The locator to find the element.</param>
        /// <param name="maxScrolls">Maximum number of scroll attempts.</param>
        /// <exception cref="NoSuchElementException">Thrown when element is not found after max scrolls.</exception>
        public void ScrollUntilVisible(By locator, int maxScrolls = 5)
        {
            int attempts = 0;
            while (attempts < maxScrolls)
            {
                if (Driver.FindElements(locator).Count > 0)
                {
                    return;
                }
                ScrollDownOnce();
                attempts++;
            }
            throw new NoSuchElementException($"Element {locator} not found after scrolling {maxScrolls} times.");
        }



    /// <summary>
    /// Adds a parameter to the Allure report for the current test case.
    /// </summary>
    /// <param name="name">The name of the parameter to add.</param>
    /// <param name="value">The value of the parameter to add.</param>
    public static void AddAllureParameters(string name, object value)
    {
        try
        {
            AllureLifecycle.Instance.UpdateTestCase(testResult =>
            {
                if (value != null && value.ToString().StartsWith("http"))
                {
                    testResult.links.Add(new Link
                    {
                        name = name,
                        url = value.ToString(),
                        type = "link"
                    });
                }
                else
                {
                    testResult.parameters.Add(new Parameter
                        {
                            name = name,
                            value = value?.ToString() ?? "null"
                        });

                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding Allure parameter: {ex.Message}");
        }
    }
}


        
    }
