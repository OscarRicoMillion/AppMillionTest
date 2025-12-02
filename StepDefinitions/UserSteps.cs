using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using AppMillionTest.Utilities; // si usas las utilidades de Reqnroll

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class UserSteps
    {
        private readonly UserPage userPage;
        private readonly LoginUserPage loginUserPage;

        private readonly LoadActions loadActions;

        public UserSteps()
        {
            var driver = IOSDriverFactory.Driver;
            userPage = new UserPage(driver);
            loginUserPage = new LoginUserPage(driver);
            loadActions = new LoadActions(driver);
        }

        [When(@"selecciona la opcion Sing out")]
        [Then(@"selecciona la opcion Sing out")]
        public void WhenSeleccionaLaOpcionSingOut()
        {
            userPage.ClickSignOutOption();
            userPage.ClickYesOption();
            Assert.That(loadActions.validateLoadingicon(), Is.True, "El ícono de carga no se comportó como se esperaba durante el log out.");
        }

        [Then(@"selecciona la opcion de cambiar status de usuario")]
        [When(@"selecciona la opcion de cambiar status de usuario")]
        public void WhenSeleccionaLaOpcionDeCambiarStatusDeUsuario()
        {
            userPage.ClickChangeStatusOption();
        }

        [Then(@"Se debe ver el estado ""(.*)"" debajo del nombre de usuario")]
        public void ThenSeDebeVerElEstadoDebajoDelNombreDeUsuario(string expectedStatus)
        {

            var visible = userPage.GetStatusText(expectedStatus);
            Assert.That(visible, Is.EqualTo(expectedStatus), $"El estado visible '{visible}' no coincide con el esperado '{expectedStatus}'.");

        }

        [Then(@"el usuario debe ser redirigido a la pantalla de login")]
        public void ThenElUsuarioDebeSerRedirigidoALaPantallaDeLogin()
        {
            // Verificamos que aparezca el campo de login (usando LoginUserPage)
            var isLoginVisible = loginUserPage.IsLoginScreenVisible();
            Assert.That(isLoginVisible, Is.True, "No se redirigió a la pantalla de login");
        }


    }
}
