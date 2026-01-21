using Allure.Net.Commons;
using AppMillionTest.Drivers;
using AppMillionTest.Services;
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
        /// Captures a screenshot when a step fails and uploads it to Azure Blob Storage and Allure report.
        /// </summary>
        /// <param name="scenarioContext">The current scenario context.</param>
        [AfterStep]
        public async Task CaptureScreenshotOnFailure(ScenarioContext scenarioContext)
        {
            // Capture evidence when the step fails
            if (scenarioContext.TestError != null)
            {
                try
                {
                    // Grab the driver from the factory
                    var driver = IOSDriverFactory.Driver;

                    // Capture and save the screenshot locally
                    var screenshotPath = ScreenshotService.CaptureScreenshot(
                        driver,
                        scenarioContext.ScenarioInfo.Title,
                        scenarioContext.StepContext.StepInfo.Text
                    );
                    
                    // Attach screenshot to Allure report when step fails
                    try
                    {
                        AllureApi.AddAttachment($"Screenshot - {scenarioContext.StepContext.StepInfo.Text}", "image/png", screenshotPath);
                        Console.WriteLine($"✅ Screenshot uploaded to Allure: {screenshotPath}");

                    }catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Error attaching screenshot to Allure report: {ex.Message}");
                    }

                    // Store local path in ScenarioContext
                    if (!string.IsNullOrEmpty(screenshotPath))
                    {
                        scenarioContext["FailureScreenshot"] = screenshotPath;
                        Console.WriteLine($"✅ Screenshot captured: {screenshotPath}");

                        // Upload to Azure and get public URL
                        var azureUrl = await AzureBlobService.UploadScreenshot(screenshotPath);
                        scenarioContext["AzureScreenshotUrl"] = azureUrl;
                        Console.WriteLine($"☁️ Screenshot uploaded on Azure Blob Storage: {azureUrl}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Error while capturing/uploading screenshot: {ex.Message}");
                }
            }
        }
        
    }
}
