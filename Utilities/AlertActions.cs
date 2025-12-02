using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace AppMillionTest.Utilities
{
    public class AlertActions
    {
        private readonly IOSDriver driver;

        public AlertActions(IOSDriver driver)
        {
            this.driver = driver;
        }

    

       public void AcceptSystemAlertIfPresent(int timeoutSeconds = 5)
        {
            var end = DateTime.Now.AddSeconds(timeoutSeconds);

            while (DateTime.Now < end)
            {
                try
                {
                    var alert = driver.SwitchTo().Alert();
                    alert.Dismiss();            // 👈 Acepta el permiso
                    return;
                }
                catch
                {
                    Thread.Sleep(300);        // pequeño polling
                }
            }
        }


    }
}