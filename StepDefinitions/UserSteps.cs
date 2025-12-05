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

        [Then(@"se debe cambiar el status del usuario")]
        public void ThenSeDebeCambiarElStatusDelUsuario()
        {
            var firstStatus = userPage.GetStatusText();
            Console.WriteLine($"✅ El primer status es '{firstStatus}').");
            var lastStatus = userPage.ChangeUserStatus();
            Console.WriteLine($"✅ El segundo status es '{lastStatus}').");

            Assert.That(lastStatus, Is.Not.EqualTo(firstStatus), "El estado del usuario no cambió después de la acción.");        
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
