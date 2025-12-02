using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;

namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class LeadDetailSteps
    {
        private readonly LeadDetailPage leadDetailPage;

        public LeadDetailSteps()
        {
            var driver = IOSDriverFactory.Driver;
            leadDetailPage = new LeadDetailPage(driver);
        }

        [When(@"selecciona el icono add para agregar una actividad")]
        public void WhenSeleccionaElIconoDeAgregarActividad()
        {
            leadDetailPage.ClickAddActivityIcon();
        }
    }
}
