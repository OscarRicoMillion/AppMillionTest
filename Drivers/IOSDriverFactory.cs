using System.Security.Cryptography.X509Certificates;
using AppMillionTest.Configuration;
using Microsoft.VisualBasic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;


namespace AppMillionTest.Drivers
{
    /// <summary>
    /// Factory for the iOS Appium session. Manages creation, teardown, and relaunching the app.
    /// </summary>
    public static class IOSDriverFactory
    {
        // Shared iOS driver instance
        private static IOSDriver? _driver;

        /// <summary>
        /// Gets the current iOS driver instance.
        /// </summary>
        public static IOSDriver Driver => _driver ?? throw new InvalidOperationException("Driver not initialized.");

        /// <summary>
        /// Path to the .app bundle from appsettings file
        /// </summary>
        private static string AppPath => ConfigService.Instance.GetAppPath();

        /// <summary>
        /// Real bundle identifier used to close/reopen the app.
        /// </summary>
        public const string MillionAndUpBundleId = "com.MillionAndUp.mau";

        /// <summary>
        /// Starts an Appium session if one is not already running.
        /// </summary>
        public static void StartSession()
        {
            // Reuse the existing driver when possible
            if (_driver != null)
                return;

            bool isPipeline = ConfigService.Instance.GetEnviromentConfig();

            // Configure Appium options
            var options = new AppiumOptions
            {
                PlatformName = "iOS",
                AutomationName = "XCUITest",
                DeviceName = ConfigService.Instance.GetDeviceName(),
                PlatformVersion = ConfigService.Instance.GetPlatformVersion()
            };

            // Configure app installation based on environment
            if (isPipeline)
            {   
                // Pipeline: Install app from bundle to ensure clean state
                options.App = AppPath;
            }
            else
            {   
                // Local: Use already installed app for faster execution
                options.AddAdditionalAppiumOption("bundleId", MillionAndUpBundleId);
            }

            options.AddAdditionalAppiumOption("udid", "9D760A97-D324-4C1B-BFB9-D0FCB18BF35D"); // iPhone 17 Pro Max

            // Reset app data between scenarios to require fresh login each time
            options.AddAdditionalAppiumOption("noReset", false);

            options.AddAdditionalAppiumOption("useNewWDA", false); // Reuse WDA instance for speed            
            options.AddAdditionalAppiumOption("autoDismissAlerts", true);

            // Other helpful options
            options.AddAdditionalAppiumOption("newCommandTimeout", 300);
            options.AddAdditionalAppiumOption("wdaLocalPort", 8100);
            options.AddAdditionalAppiumOption("preventWDAAttachments", true);
            options.AddAdditionalAppiumOption("wdaLaunchTimeout", 10000);
            options.AddAdditionalAppiumOption("wdaConnectionTimeout", 10000);
            options.AddAdditionalAppiumOption("connectHardwareKeyboard", true);
            options.AddAdditionalAppiumOption("wdaStartupRetries", 3);
            options.AddAdditionalAppiumOption("wdaStartupRetryInterval", 5000);
            options.AddAdditionalAppiumOption("reduceMotion", true);
            options.AddAdditionalAppiumOption("reduceTransparency", true);

            // Create the driver
            _driver = new IOSDriver(new Uri("http://127.0.0.1:4723"), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        /// <summary>
        /// Completely stops the Appium session.
        /// </summary>
        public static void StopSession()
        {
            _driver?.Quit();
            _driver = null;
        }

        /// <summary>
        /// Launches the app identified by the bundle id.
        /// </summary>
        public static void LaunchApp()
        {
            _driver?.ExecuteScript("mobile: launchApp", new Dictionary<string, object>
            {
                { "bundleId", MillionAndUpBundleId }
            });
        }

        /// <summary>
        /// Terminates the app without closing the entire session.
        /// </summary>
        public static void CloseApp()
        {
            _driver?.ExecuteScript("mobile: terminateApp", new Dictionary<string, object>
            {
                { "bundleId", MillionAndUpBundleId }
            });
        }
    }
}
