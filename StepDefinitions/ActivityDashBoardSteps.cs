using NUnit.Framework;
using AppMillionTest.Drivers;
using AppMillionTest.Pages;
using Reqnroll;
using OpenQA.Selenium.Appium;
using AppMillionTest.Utilities;
using System.Globalization;


namespace AppMillionTest.StepDefinitions
{
    [Binding]
    public class ActivityDashBoardSteps : CommonMethods
    {
        private readonly ActivityDashBoardPage activityDashBoardPage;
        private readonly LeadDetailPage leadDetailPage;
        private readonly LoadActions loadActions;
        private readonly ScenarioContext scenarioContext;

        public ActivityDashBoardSteps(ScenarioContext scenarioContext) : base(IOSDriverFactory.Driver)
        {

            activityDashBoardPage = new ActivityDashBoardPage(Driver);
            leadDetailPage = new LeadDetailPage(Driver);
            this.scenarioContext = scenarioContext;
            loadActions = new LoadActions(Driver);

        }

        [When(@"selecciona la opcion '(.*)'")]
        public void WhenSeleccionaLaOpcion(string option)
        {
            activityDashBoardPage.SelectNoteOption();
        }

        [When(@"ingresa el texto de la nota '([^']*)'")]
        public void WhenIngresaElTextoDeLaNota(string note)
        {
            activityDashBoardPage.EnterNoteText(note);
            scenarioContext["noteText"] = note;
        }

        [When(@"selecciona el boton Save Notes")]
        public void WhenSeleccionaElBotonSaveNotes()
        {
            activityDashBoardPage.ClickSaveNotes();
            Assert.That(loadActions.validateLoadingicon(), Is.True, "La pantalla de carga no se completó a tiempo.");
        }

        [Then(@"se debe crear una actividad tipo nota con el texto agregado previamente, la fecha actual y el nombre del agente '([^']*)'")]

        public void ThenSeDebeCrearUnaActividadTipoNotaConElTextoAgregadoPreviamenteLaFechaActualYElNombreDelAgente(string agentName)
        {
            
            var note = scenarioContext["noteText"] as string;

            // Get the text from the lead detail page and compare
            var actualNote = leadDetailPage.GetLatestNoteText();
            Assert.That(actualNote, Does.Contain(note), "La nota creada no coincide con el texto ingresado.");
            Assert.That(actualNote, Does.Contain(agentName), "Se esperaba que la nota contuviera el nombre del agente.");


            var CurrentDate = DateTime.Now.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
            Assert.That(actualNote, Does.Contain(CurrentDate), "La nota creada no contiene la fecha actual.");

            Console.WriteLine($"✅ Fecha actual: {CurrentDate}");
            Console.WriteLine($"✅ Nota esperada: {note}");
            Console.WriteLine($"✅ Nota actual: {actualNote}");
            Console.WriteLine($"✅ Agente esperado: {agentName}");

        }

        [Then(@"the user goes back to the lead list")]

        public void ThenTheUserGoesBackToTheLeadList()
        {
            goBack();
        }

        
        
    }
}
