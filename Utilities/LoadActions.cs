using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AppMillionTest.Utilities
{
    public class LoadActions
    {
        private readonly IOSDriver driver;

        public LoadActions(IOSDriver driver)
        {
            this.driver = driver;
        }

        public bool validateLoadingicon()
        {

            string iconAccessibilityId = "LoadingPress";
            TimeSpan timeout = TimeSpan.FromSeconds(10); // Tiempo máximo para la validación completa

            // Inicializa el WebDriverWait
            var wait = new WebDriverWait(driver, timeout);

            
            By iconLocator = MobileBy.AccessibilityId(iconAccessibilityId);

            try
            {
                var iconElementDisplay = wait.Until(ExpectedConditions.ElementIsVisible(iconLocator));

                Console.WriteLine("✅ Ícono 'LoadingPress' encontrado (el proceso de log out ha iniciado).");


                var iconelementNotDisplayed = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(iconLocator));
                Console.WriteLine("✅ El ícono 'LoadingPress' ha desaparecido (el proceso de log out ha finalizado).");

                // Validamos que ambos pasos ocurrieron: se mostró y posteriormente desapareció
                var wasVisible = iconElementDisplay != null;
                return wasVisible && iconelementNotDisplayed;

            }
            catch (WebDriverTimeoutException)
            {
              
                Console.WriteLine($"❌ Falla de validación: El ícono '{iconAccessibilityId}' no apareció o no desapareció a tiempo.");
                throw; // Relanza la excepción para que la prueba falle
            }
        }

        
    }
}