using AppMillionTest.Drivers;
using Reqnroll;

namespace AppMillionTest.Hooks
{
    /// <summary>
    /// Hooks for managing the Appium session lifecycle across test runs.
    /// </summary>
    [Binding]
    public class SessionHooks
    {
        /// <summary>
        /// Starts the Appium session before any test runs.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            IOSDriverFactory.StartSession();
        }

        /// <summary>
        /// Stops the Appium session after all tests have run.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun()
        {
            IOSDriverFactory.StopSession();
        }
    }
}
