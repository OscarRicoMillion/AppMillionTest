using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AppMillionTest.Utilities
{
    public abstract class CommonMethods
    {
        // Referencia compartida al driver iOS que se reutiliza en todos los helpers
        protected IOSDriver Driver { get; }
        // Tiempo de espera por defecto (en segundos) para todas las operaciones de espera
        private const int DefaultWaitSeconds = 20;

        // Constructor que recibe la instancia del driver y la almacena para uso posterior
        public CommonMethods(IOSDriver driver)
        {
            Driver = driver;
        }      

        //validar si un elemento es visible en pantalla
        public bool IsElementVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitSeconds));
                var el = wait.Until(d => d.FindElement(locator));
                return el != null && el.Displayed;
            }
            catch
            {
                return false;                
            }
        }   

        // Crea una instancia de WebDriverWait con el timeout por defecto
        private WebDriverWait CreateWait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitSeconds));
        }

        // Navega un paso hacia atrás dentro de la vista actual usando el botón accesible
        public void goBack()
        {
            var backButton = Driver.FindElement(MobileBy.AccessibilityId("TEST_ID_DETAIL_LEAD_GO_BACK")); // Botón estándar para retroceder
            backButton.Click();
        }

        // Espera a que un localizador sea cliqueable y ejecuta el tap
        public void Click(By locator)
        {
            var element = CreateWait().Until(ExpectedConditions.ElementToBeClickable(locator)); // Elemento listo para recibir el tap
            element.Click();
        }

        // Envía texto a un elemento visible limpiando siempre el campo antes de escribir
        public void SendKeys(By locator, string text)
        {
            var element = CreateWait().Until(ExpectedConditions.ElementIsVisible(locator)); // Campo objetivo para ingresar texto
            element.Clear();
            element.SendKeys(text);
        }

       
        // Realiza un tap directamente en coordenadas absolutas, útil cuando no hay identificador
        public void ClickByCoordinates(int x, int y)
        {
            // Direct coordinate tap helps when elements lack stable identifiers
            var scriptArgs = new Dictionary<string, object>
            {
                { "x", x },
                { "y", y },
                { "tapCount", 1 }
            };
            Driver.ExecuteScript("mobile: tap", scriptArgs);
        }

        // Obtiene el texto visible de un elemento aplicando un wait explícito
        public string GetElementText(By locator)
        {
            var element = CreateWait().Until(ExpectedConditions.ElementIsVisible(locator)); // Elemento del cual se necesita el texto
            return element.Text?.Trim() ?? string.Empty;
        }

        // Obtiene la colección completa de elementos que coinciden con un localizador dado
        public IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            CreateWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator)); // Asegura que al menos un elemento esté presente
            return Driver.FindElements(locator); // Colección resultante para futuras iteraciones
        }

        // Helper específico cuando se requiere recuperar elementos por nombre de clase
        public IReadOnlyCollection<IWebElement> GetElementsByClassName(string className)
        {
            return GetElements(MobileBy.ClassName(className));
        }

        // Ejecuta un desplazamiento vertical corto utilizando el gesto nativo de swipe
        public void ScrollDownOnce()
        {
            var scriptArgs = new Dictionary<string, object>
            {
                { "direction", "down" },
                { "velocity", "fast" }
            };
            Driver.ExecuteScript("mobile: swipe", scriptArgs);
        }

        // Repite desplazamientos hasta encontrar el elemento solicitado o agotar el límite
        public void ScrollUntilVisible(By locator, int maxScrolls = 5)
        {
            int attempts = 0; // Contador de desplazamientos realizados
            while (attempts < maxScrolls)
            {
                if (Driver.FindElements(locator).Count > 0) // Elemento encontrado sin necesidad de seguir desplazando
                {
                    return;
                }
                ScrollDownOnce();
                attempts++;
            }
            throw new NoSuchElementException($"Element {locator} not found after scrolling {maxScrolls} times.");
        }

        
    }
}