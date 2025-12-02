using AppMillionTest.Drivers;
using Reqnroll;

namespace AppMillionTest.Hooks
{
    [Binding]
    public class SessionHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            IOSDriverFactory.StartSession();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            IOSDriverFactory.StopSession();
        }
    }
}
