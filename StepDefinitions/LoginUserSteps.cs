using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class LoginUserSteps
    {
        private readonly LoginUserPage loginUserPage;


        public LoginUserSteps()
        {
            var driver = IOSDriverFactory.Driver;
            loginUserPage = new LoginUserPage(driver);

        }

        [Given(@"el usuario abre la app Million")]
        public void GivenElUsuarioAbreLaAppMillion()
        {
            IOSDriverFactory.LaunchApp();
        }

        [When(@"ingresa el nombre de usuario ""(.*)""")]
        public void WhenIngresaElNombreDeUsuario(string username)
        {
           loginUserPage.IngresarNombreDeUsuario(username);
        }

        [When(@"selecciona el boton continue")]
        public void WhenSeleccionaElBotonContinue()
        {
            loginUserPage.ClickContinueButton();
        }






    }
}
