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
    public class ActivityDashBoardSteps
    {
        private readonly ActivityDashBoardPage activityDashBoardPage;
        private readonly LeadDetailPage leadDetailPage;

        private readonly LoadActions loadActions;

        private readonly CommonMethods commonMethods;
        private readonly ScenarioContext scenarioContext;

        public ActivityDashBoardSteps(ScenarioContext scenarioContext)
        {
            var driver = IOSDriverFactory.Driver;
            activityDashBoardPage = new ActivityDashBoardPage(driver);
            leadDetailPage = new LeadDetailPage(driver);
            this.scenarioContext = scenarioContext;
            loadActions = new LoadActions(driver);
            commonMethods = new CommonMethods(driver);
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
            var note = scenarioContext.ContainsKey("noteText") ? scenarioContext["noteText"] as string : null;
            Assert.That(note, Is.Not.Null, "No se encontró el texto de la nota en ScenarioContext");

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
            commonMethods.goBack();
        }

        [Then(@"se debe ver la hora y fecha de creacion")]
        public void ThenSeDebeVerLaHoraYFechaDeCreacion()
        {
            Assert.That(activityDashBoardPage.IsCreationTimestampVisible(), Is.True, "No se visualiza la hora y fecha de creación.");
        }

        [Then(@"se debe ver el nombre del usuario que creo la nota '([^']*)'")]
        public void ThenSeDebeVerElNombreDelUsuarioQueCreoLaNota(string author)
        {
            Assert.That(activityDashBoardPage.IsAuthorVisible(author), Is.True, $"No se visualiza el autor '{author}'.");
        }
    }
}
