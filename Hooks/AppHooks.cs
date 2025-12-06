using AppMillionTest.Drivers;
using AppMillionTest.Utilities;
using Reqnroll;
using System;

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

        [AfterStep]
        public void CaptureScreenshotOnFailure(ScenarioContext scenarioContext)
        {
            // Verificar si el step falló
            if (scenarioContext.TestError != null)
            {
                try
                {
                    // Obtener driver desde IOSDriverFactory
                    var driver = IOSDriverFactory.Driver;

                    // Capturar y guardar screenshot
                    var screenshotPath = ScreenshotHelper.CaptureScreenshot(
                        driver,
                        scenarioContext.ScenarioInfo.Title,
                        scenarioContext.StepContext.StepInfo.Text
                    );

                    // Guardar ruta en ScenarioContext para uso futuro (Allure, Azure, etc.)
                    if (!string.IsNullOrEmpty(screenshotPath))
                    {
                        scenarioContext["FailureScreenshot"] = screenshotPath;
                        Console.WriteLine($"✅ Screenshot capturado y guardado para step fallido.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Error al intentar capturar screenshot: {ex.Message}");
                }
            }
        }
        
    }
}
