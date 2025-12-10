using AppMillionTest.Drivers;
using AppMillionTest.Infrastructure;
using Reqnroll;
using System;

namespace AppMillionTest.Hooks
{
    /// <summary>
    /// Hooks for managing app lifecycle and capturing screenshots on test failures.
    /// </summary>
    [Binding]
    public class AppHooks
    {
        /// <summary>
        /// Launches the app before each scenario.
        /// </summary>
        [BeforeScenario]
        public void LaunchSettings()
        {
            IOSDriverFactory.LaunchApp();
        }

        /// <summary>
        /// Closes the app after each scenario.
        /// </summary>
        [AfterScenario]
        public void CloseSettings()
        {
            IOSDriverFactory.CloseApp();
         
        }

        /// <summary>
        /// Captures a screenshot when a step fails.
        /// </summary>
        /// <param name="scenarioContext">The current scenario context.</param>
        [AfterStep]
        public void CaptureScreenshotOnFailure(ScenarioContext scenarioContext)
        {
            // Capture evidence when the step fails
            if (scenarioContext.TestError != null)
            {
                try
                {
                    // Grab the driver from the factory
                    var driver = IOSDriverFactory.Driver;

                    // Capture and save the screenshot
                    var screenshotPath = ScreenshotService.CaptureScreenshot(
                        driver,
                        scenarioContext.ScenarioInfo.Title,
                        scenarioContext.StepContext.StepInfo.Text
                    );

                    // Store path in ScenarioContext for future reporting hooks
                    if (!string.IsNullOrEmpty(screenshotPath))
                    {
                        scenarioContext["FailureScreenshot"] = screenshotPath;
                        Console.WriteLine("✅ Screenshot captured for failing step.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Error while capturing screenshot: {ex.Message}");
                }

               
            }
        }
        
    }
}
