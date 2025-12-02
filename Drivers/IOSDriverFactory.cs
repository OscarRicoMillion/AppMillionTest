using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace AppMillionTest.Drivers
{
    /// <summary>
    /// Fábrica para la sesión iOS Appium. Controla creación, cierre y relanzamiento de apps.
    /// </summary>
    public static class IOSDriverFactory
    {   
        // Instancia del driver iOS
        private static IOSDriver? _driver;

        /// <summary>
        /// Obtiene la instancia actual del driver iOS.
        /// </summary>
        public static IOSDriver Driver => _driver ?? throw new InvalidOperationException("Driver no inicializado.");

        // Ruta de tu .app
        public const string AppPath = "/Users/daniel/Documents/AppMillionTest/AppMillionTest/App/MillionAndUp.app";

        // El bundleId real de tu app (lo vas a usar SOLO para cerrar/reabrir)
        public const string MillionAndUpBundleId = "com.MillionAndUp.mau";

        /// <summary>
        /// Inicia una sesión Appium si no existe.
        /// </summary>
        public static void StartSession()
        {   
            // Si ya hay un driver, no hagas nada
            if (_driver != null)
                return;

            // Configura las opciones de Appium
            var options = new AppiumOptions
            {
                PlatformName = "iOS",
                AutomationName = "XCUITest",
                //DeviceName = "iPhone 16", // debe coincidir con el simulador existente
                DeviceName = "iPhone 17 Pro Max", // debe coincidir con el simulador existente
                PlatformVersion = "26.1"
            };

            // linea para usar la app .app directamente
            options.App = AppPath;

            // linea para usar el bundleId (opcional)
            //options.AddAdditionalAppiumOption("bundleId", MillionAndUpBundleId);

            // � Especifica tu UDID real desde el simulador
            // lo obtienes con: `xcrun simctl list devices`
            //options.AddAdditionalAppiumOption("udid", "B629C756-DDC8-4524-8C51-8F99F32A73C4"); //16
            options.AddAdditionalAppiumOption("udid", "9D760A97-D324-4C1B-BFB9-D0FCB18BF35D"); //17 max

            // � Mantén la sesión viva entre escenarios
            options.AddAdditionalAppiumOption("noReset", false);
            options.AddAdditionalAppiumOption("useNewWDA", false); // ⚡️ evita recompilar WDA            
            options.AddAdditionalAppiumOption("autoDismissAlerts", true);          
           
            // Otras opciones útiles
            options.AddAdditionalAppiumOption("newCommandTimeout", 300);
            options.AddAdditionalAppiumOption("wdaLaunchTimeout", 60000);
            options.AddAdditionalAppiumOption("wdaConnectionTimeout", 60000);
            options.AddAdditionalAppiumOption("wdaStartupRetries", 3);
            options.AddAdditionalAppiumOption("wdaStartupRetryInterval", 5000);
            options.AddAdditionalAppiumOption("reduceMotion", true);
            options.AddAdditionalAppiumOption("reduceTransparency", true);

            // Crea el driver
            _driver = new IOSDriver(new Uri("http://127.0.0.1:4723"), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// Cierra completamente la sesión Appium.
        /// </summary>
        public static void StopSession()
        {
            _driver?.Quit();
            _driver = null;
        }

        /// <summary>
        /// Lanza la app especificada.
        /// </summary>
        public static void LaunchApp()
        {
            _driver?.ExecuteScript("mobile: launchApp", new Dictionary<string, object>
            {
                { "bundleId", MillionAndUpBundleId }
            });
        }

        /// <summary>
        /// Termina la app especificada sin cerrar la sesión completa.
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
