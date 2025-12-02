using AppMillionTest.Drivers;
using Reqnroll;

namespace AppMillionTest.Hooks
{
    [Binding]
    public class AppHooks
    {

        [BeforeScenario]
        public void LaunchSettings()
        {
            IOSDriverFactory.LaunchApp();
        }

        [AfterScenario]
        public void CloseSettings()
        {
            IOSDriverFactory.CloseApp();
         
        }
    }
}
