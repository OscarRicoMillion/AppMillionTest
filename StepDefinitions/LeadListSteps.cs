using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium; // si usas las utilidades de Reqnroll

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class LeadListSteps
    {
        private readonly LeadListPage leadListPage;
        private readonly UserPage userPage;
        public LeadListSteps()
        {
            var driver = IOSDriverFactory.Driver;
            leadListPage = new LeadListPage(driver);
            userPage = new UserPage(driver);
        }

        [Then(@"se debe cargar el listado de leads con el icono de usuario visible")]
        public void ThenSeDebeCargarElListadoDeLeadsConElIconoDeUsuarioVisible()
        {
            var UserIconVisible = leadListPage.IconUserIsPresent();  

            Assert.That(UserIconVisible, Is.True, "El icono de usuario no está visible en el listado de leads.");
        }

         [When(@"selecciona el icono de usuario")]
        public void WhenSeleccionaElIconoDeUsuario()
        {
            leadListPage.ClickUserIcon();
        }

        [When(@"Selecciona un lead de la lista")]
        public void WhenSeleccionaUnLeadDeLaLista()
        {
            leadListPage.ClickFirstLead();
        }
    }
}
