using System;
using System.IO;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;

namespace AppMillionTest.Utilities
{
    /// <summary>
    /// Helper class for capturing and saving screenshots during test execution.
    /// </summary>
    public static class ScreenshotHelper
    {
        private const string ReportsFolder = "Reports";

        /// <summary>
        /// Captures a screenshot from the iOS driver and saves it locally.
        /// </summary>
        /// <param name="driver">The active IOSDriver instance.</param>
        /// <param name="scenarioTitle">Title of the scenario for naming.</param>
        /// <param name="stepText">Text of the step for naming.</param>
        /// <returns>Full path to the saved screenshot file.</returns>
        public static string CaptureScreenshot(IOSDriver driver, string scenarioTitle, string stepText)
        {
            if (driver == null)
            {
                Console.WriteLine("⚠️ Driver is null, cannot capture screenshot.");
                return string.Empty;
            }

            try
            {
                // Capture the screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                // Generate sanitized filename
                string fileName = GenerateFileName(scenarioTitle, stepText);

                // Ensure Reports directory exists
                string reportsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ReportsFolder);
                Directory.CreateDirectory(reportsPath);

                // Full path for the screenshot
                string fullPath = Path.Combine(reportsPath, fileName);

                // Save the screenshot
                screenshot.SaveAsFile(fullPath);

                Console.WriteLine($"📸 Screenshot saved: {fullPath}");
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to capture screenshot: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Generates a sanitized filename for the screenshot based on scenario and step info.
        /// </summary>
        /// <param name="scenarioTitle">Scenario title.</param>
        /// <param name="stepText">Step text.</param>
        /// <returns>Sanitized filename with timestamp.</returns>
        private static string GenerateFileName(string scenarioTitle, string stepText)
        {
            // Sanitize scenario title and step text (remove invalid characters)
            string sanitizedScenario = SanitizeFileName(scenarioTitle);
            string sanitizedStep = SanitizeFileName(stepText);

            // Generate timestamp
            string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");

            // Construct filename - screenshot
            return $"{sanitizedScenario}_{sanitizedStep}_{timestamp}.png";
        }

        /// <summary>
        /// Removes invalid characters from a string to make it filename-safe.
        /// </summary>
        /// <param name="input">Input string to sanitize.</param>
        /// <returns>Sanitized string safe for filenames.</returns>
        private static string SanitizeFileName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "unknown";

            // Replace spaces with underscores and remove invalid filename characters
            string sanitized = input.Replace(" ", "_");
            sanitized = Regex.Replace(sanitized, @"[^\w\-_]", "");

            // Limit length to avoid overly long filenames
            if (sanitized.Length > 50)
                sanitized = sanitized.Substring(0, 50);

            return sanitized;
        }
    }
}
